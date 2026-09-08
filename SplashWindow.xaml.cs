using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using DaBoyzApp.Services;

namespace DaBoyzApp;

public partial class SplashWindow : Window
{
    private GitHubRelease? _availableUpdate;

    public SplashWindow()
    {
        InitializeComponent();

        Loaded += SplashWindow_Loaded;
    }

    private async void SplashWindow_Loaded(
        object sender,
        RoutedEventArgs e)
    {
        VersionText.Text = $"v{GetCurrentVersion()} BETA";
        // =========================================================
        // LOGO FADE + SLIDE
        // =========================================================

        DoubleAnimation logoFade =
            new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromMilliseconds(600)
            };

        DoubleAnimation logoSlide =
            new DoubleAnimation
            {
                From = 15,
                To = 0,
                Duration = TimeSpan.FromMilliseconds(600),
                EasingFunction =
                    new QuadraticEase
                    {
                        EasingMode =
                            EasingMode.EaseOut
                    }
            };

        LogoText.BeginAnimation(
            OpacityProperty,
            logoFade);

        ((TranslateTransform)LogoText.RenderTransform)
            .BeginAnimation(
                TranslateTransform.YProperty,
                logoSlide);


        // =========================================================
        // SUBTITLE
        // =========================================================

        await Task.Delay(300);

        DoubleAnimation subtitleFade =
            new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromMilliseconds(500)
            };

        SubtitleText.BeginAnimation(
            OpacityProperty,
            subtitleFade);


        // =========================================================
        // STATUS
        // =========================================================

        await Task.Delay(400);

        DoubleAnimation statusFade =
            new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromMilliseconds(400)
            };

        StatusText.BeginAnimation(
            OpacityProperty,
            statusFade);

        StatusText.Text =
            "INITIALIZING COMMUNITY HUB...";


        // =========================================================
        // LOADING
        // =========================================================

        await AnimateLoadingBar(
            70,
            500);

        StatusText.Text =
            "LOADING DATABASE...";

        await AnimateLoadingBar(
            150,
            450);

        StatusText.Text =
            "LOADING SERVICES...";

        await AnimateLoadingBar(
            225,
            450);


        // =========================================================
        // CHECK FOR UPDATES
        // =========================================================

        StatusText.Text =
            "CHECKING FOR UPDATES...";

        await CheckForUpdates();


        // =========================================================
        // SYSTEM READY
        // =========================================================

        StatusText.Text =
            "SYSTEM READY";

        await AnimateLoadingBar(
            280,
            400);


        // =========================================================
        // PAUSE
        // =========================================================

        await Task.Delay(350);


        // =========================================================
        // FADE OUT
        // =========================================================

        DoubleAnimation fadeOut =
            new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromMilliseconds(500)
            };

        fadeOut.Completed +=
            (_, _) =>
            {
                ShowNextWindow();
            };

        BeginAnimation(
            OpacityProperty,
            fadeOut);
    }


    // =============================================================
    // CHECK FOR UPDATES
    // =============================================================

    private async Task CheckForUpdates()
    {
        try
        {
            UpdateService updateService =
                new UpdateService();

            _availableUpdate =
                await updateService.GetAvailableUpdateAsync();
        }
        catch
        {
            // If GitHub cannot be reached,
            // simply continue starting the application.
            _availableUpdate = null;
        }
    }


    // =============================================================
    // SHOW NEXT WINDOW
    // =============================================================

    private void ShowNextWindow()
    {
        if (_availableUpdate != null)
        {
            string currentVersion =
                GetCurrentVersion();

            string latestVersion =
                _availableUpdate.Tag_Name ?? "Unknown";

            UpdateWindow updateWindow =
                new UpdateWindow(
                    currentVersion,
                    _availableUpdate);

            updateWindow.ShowDialog();
        }


        // =========================================================
        // MAIN WINDOW
        // =========================================================

        MainWindow mainWindow =
            new MainWindow();

        Application.Current.MainWindow =
            mainWindow;

        mainWindow.Show();

        Close();
    }


    // =============================================================
    // GET CURRENT APPLICATION VERSION
    // =============================================================

    private string GetCurrentVersion()
    {
        Assembly assembly =
            Assembly.GetExecutingAssembly();

        Version? version =
            assembly.GetName().Version;

        return version?.ToString(3) ?? "Unknown";
    }


    // =============================================================
    // LOADING BAR ANIMATION
    // =============================================================

    private async Task AnimateLoadingBar(
        double targetWidth,
        int duration)
    {
        DoubleAnimation animation =
            new DoubleAnimation
            {
                To = targetWidth,
                Duration =
                    TimeSpan.FromMilliseconds(
                        duration),

                EasingFunction =
                    new QuadraticEase
                    {
                        EasingMode =
                            EasingMode.EaseOut
                    }
            };

        LoadingBar.BeginAnimation(
            WidthProperty,
            animation);

        await Task.Delay(duration);
    }
}