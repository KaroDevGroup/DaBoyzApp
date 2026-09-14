// KaroDevGroup
// Josh Karo

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using DaBoyzApp.Security;

namespace DaBoyzApp;

public partial class AntiCheatWindow : Window
{
    private readonly IntegrityService _integrityService = new();

    public bool ScanPassed { get; private set; }

    public AntiCheatWindow()
    {
        InitializeComponent();
    }

    private async void Window_Loaded(
        object sender,
        RoutedEventArgs e)
    {
        await RunIntegrityScanAsync();
    }

    private async Task RunIntegrityScanAsync()
    {
        ScanPassed = false;

        SecurityStateText.Text = "SCANNING";

        MainStatusText.Text =
            "SCANNING APPLICATION FILES...";

        CurrentFileText.Text =
            "Preparing integrity scan...";

        ScanProgressBar.Value = 0;

        FilesCheckedText.Text =
            "FILES CHECKED: 0 / 0";

        PercentageText.Text =
            "0%";

        await Task.Delay(350);

        var progress =
            new Progress<(int current, int total, string file)>(
                update =>
                {
                    int percentage = 0;

                    if (update.total > 0)
                    {
                        percentage =
                            (int)Math.Round(
                                (double)update.current /
                                update.total *
                                100);
                    }

                    ScanProgressBar.Value =
                        percentage;

                    PercentageText.Text =
                        $"{percentage}%";

                    FilesCheckedText.Text =
                        $"FILES CHECKED: {update.current} / {update.total}";

                    CurrentFileText.Text =
                        $"Verifying: {update.file}";
                });

        IntegrityScanResult result;

        try
        {
            result =
                await _integrityService.ScanAsync(
                    progress);
        }
        catch (Exception ex)
        {
            ShowCriticalFailure(
                $"Scanner error: {ex.Message}");

            return;
        }

        if (result.Passed)
        {
            ScanPassed = true;

            ScanProgressBar.Value = 100;

            PercentageText.Text = "100%";

            SecurityStateText.Text =
                "PROTECTED";

            SecurityStateText.Foreground =
                new SolidColorBrush(
                    Color.FromRgb(
                        80,
                        220,
                        120));

            MainStatusText.Text =
                "INTEGRITY VERIFIED";

            MainStatusText.Foreground =
                new SolidColorBrush(
                    Color.FromRgb(
                        80,
                        220,
                        120));

            CurrentFileText.Text =
                "All protected application files passed verification.";

            await Task.Delay(3000);

            DialogResult = true;

            Close();

            return;
        }

        IntegrityFileResult? failedFile =
            result.Files.FirstOrDefault(
                file =>
                    file.Status !=
                    IntegrityFileStatus.Valid);

        string failureDescription;

        if (failedFile == null)
        {
            failureDescription =
                "Unknown integrity failure.";
        }
        else
        {
            failureDescription =
                failedFile.Status switch
                {
                    IntegrityFileStatus.Missing =>
                        $"Missing protected file:\n{failedFile.Path}",

                    IntegrityFileStatus.Modified =>
                        $"Modified protected file:\n{failedFile.Path}",

                    _ =>
                        $"Integrity failure:\n{failedFile.Path}"
                };
        }

        ShowCriticalFailure(
            failureDescription);
    }

    private void ShowCriticalFailure(
        string message)
    {
        ScanPassed = false;

        SecurityStateText.Text =
            "FAILED";

        SecurityStateText.Foreground =
            new SolidColorBrush(
                Color.FromRgb(
                    255,
                    59,
                    59));

        MainStatusText.Text =
            "INTEGRITY CHECK FAILED";

        MainStatusText.Foreground =
            new SolidColorBrush(
                Color.FromRgb(
                    255,
                    59,
                    59));

        CurrentFileText.Text =
            "DaBoyzApp detected an invalid application state.";

        FailureFileText.Text =
            message;

        FailurePanel.Visibility =
            Visibility.Visible;

        CloseButton.Visibility =
            Visibility.Visible;
    }

    private void CloseButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        DialogResult = false;

        Close();
    }
}