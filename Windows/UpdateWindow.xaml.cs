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

    private void LaterButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        Close();
    }

    private async void UpdateButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        try
        {
            UpdateButton.IsEnabled = false;
            LaterButton.IsEnabled = false;

            UpdateButton.Content = "DOWNLOADING...";

            ReleaseDescriptionText.Text =
                "Downloading the latest version...";

            UpdateService updateService =
                new UpdateService();

            Progress<double> progress =
                new Progress<double>(
                    percentage =>
                    {
                        UpdateButton.Content =
                            $"DOWNLOADING {percentage:0}%";
                    });

            string? installerPath =
                await updateService.DownloadInstallerAsync(
                    _release,
                    progress);

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

                UpdateButton.Content =
                    "UPDATE NOW";

                UpdateButton.IsEnabled = true;
                LaterButton.IsEnabled = true;

                return;
            }

            ReleaseDescriptionText.Text =
                "Update downloaded successfully. " +
                "Starting the installer...";

            await Task.Delay(500);

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

            UpdateButton.Content =
                "UPDATE NOW";

            UpdateButton.IsEnabled = true;
            LaterButton.IsEnabled = true;
        }
    }
}