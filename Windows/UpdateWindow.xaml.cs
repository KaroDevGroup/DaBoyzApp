using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using DaBoyzApp.Services;

namespace DaBoyzApp;

public partial class UpdateWindow : Window
{
    private readonly GitHubRelease _release;

    public UpdateWindow(
        string currentVersion,
        GitHubRelease release)
    {
        InitializeComponent();

        _release = release;

        CurrentVersionText.Text =
            currentVersion;

        LatestVersionText.Text =
            release.Tag_Name ?? "Unknown";

        if (!string.IsNullOrWhiteSpace(release.Body))
        {
            ReleaseDescriptionText.Text =
                release.Body;
        }
    }

    // =============================================================
    // LATER
    // =============================================================

    private void LaterButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        Close();
    }

    // =============================================================
    // UPDATE NOW
    // =============================================================

    private async void UpdateButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        try
        {
            UpdateButton.IsEnabled = false;
            LaterButton.IsEnabled = false;

            // -----------------------------------------------------
            // SHOW DOWNLOAD PROGRESS
            // -----------------------------------------------------

            DownloadProgressPanel.Visibility =
                Visibility.Visible;

            DownloadProgressBar.Width = 0;

            DownloadPercentageText.Text =
                "0%";

            DownloadStatusText.Text =
                "DOWNLOADING UPDATE...";

            ReleaseDescriptionText.Text =
                "Downloading the latest version...";

            UpdateButton.Content =
                "DOWNLOADING...";


            // -----------------------------------------------------
            // DOWNLOAD UPDATE
            // -----------------------------------------------------

            UpdateService updateService =
                new UpdateService();

            Progress<double> progress =
                new Progress<double>(
                    percentage =>
                    {
                        // Update progress bar
                        double maximumWidth =
                            DownloadProgressBar
                                .Parent is FrameworkElement parent
                                ? parent.ActualWidth
                                : 460;

                        DownloadProgressBar.Width =
                            maximumWidth *
                            (percentage / 100.0);

                        // Update percentage text
                        DownloadPercentageText.Text =
                            $"{percentage:0}%";

                        // Update button text
                        UpdateButton.Content =
                            $"DOWNLOADING {percentage:0}%";
                    });


            string? installerPath =
                await updateService.DownloadInstallerAsync(
                    _release,
                    progress);


            // -----------------------------------------------------
            // DOWNLOAD FAILED
            // -----------------------------------------------------

            if (string.IsNullOrWhiteSpace(installerPath))
            {
                MessageBox.Show(
                    "DaBoyzApp could not download the update.\n\n" +
                    "Make sure the GitHub release contains:\n" +
                    "DaBoyzApp-Setup.exe",
                    "Da Boyz - Update Failed",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );

                DownloadProgressPanel.Visibility =
                    Visibility.Collapsed;

                UpdateButton.Content =
                    "UPDATE NOW";

                UpdateButton.IsEnabled = true;
                LaterButton.IsEnabled = true;

                return;
            }


            // -----------------------------------------------------
            // DOWNLOAD COMPLETE
            // -----------------------------------------------------

            DownloadProgressBar.Width =
                460;

            DownloadPercentageText.Text =
                "100%";

            DownloadStatusText.Text =
                "DOWNLOAD COMPLETE";

            UpdateButton.Content =
                "STARTING...";

            ReleaseDescriptionText.Text =
                "Update downloaded successfully. " +
                "Starting the installer...";


            await Task.Delay(500);


            // -----------------------------------------------------
            // START INSTALLER
            // -----------------------------------------------------

            Process.Start(
                new ProcessStartInfo
                {
                    FileName = installerPath,
                    UseShellExecute = true
                }
            );

            Application.Current.Shutdown();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                "Something went wrong while updating DaBoyzApp.\n\n" +
                ex.Message,
                "Da Boyz - Update Failed",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );

            DownloadProgressPanel.Visibility =
                Visibility.Collapsed;

            UpdateButton.Content =
                "UPDATE NOW";

            UpdateButton.IsEnabled = true;
            LaterButton.IsEnabled = true;
        }
    }
}