using System.Security.AccessControl;
using System.Windows;
using System.Windows.Controls;
using DaBoyzApp.Services;

namespace DaBoyzApp.Pages;

public partial class DecisionsPage : Page
{
    public DecisionsPage()
    {
        InitializeComponent();

        Loaded += DecisionsPage_Loaded;
    }


    // ================================================================
    // CARD ANIMATION
    // ================================================================

    private void DecisionsPage_Loaded(
        object sender,
        RoutedEventArgs e)
    {
        CardAnimationService.Stagger(
            new[]
            {
                WarnButton,
                TimeoutButton,
                KickButton,
                BanButton,
                UnbanButton,
                ClearButton,
                LockButton,
                UnlockButton
            });
    }


    // ================================================================
    // WARN
    // ================================================================

    private void Warn_Click(
        object sender,
        RoutedEventArgs e)
    {
        NavigationService?.Navigate(
            new WarnMemberPage());
    }


    // ================================================================
    // COMING SOON ACTIONS
    // ================================================================

    private void BackButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        if (Application.Current.MainWindow
            is MainWindow mainWindow)
        {
            mainWindow.NavigateToAdminDashboard();
        }
    }

    private void Timeout_Click(
        object sender,
        RoutedEventArgs e)
    {
        NavigationService?.Navigate(
            new TimeoutMemberPage());
    }

    private void Kick_Click(
        object sender,
        RoutedEventArgs e)
    {
        NavigationService?.Navigate(
            new KickMemberPage());
    }

    private void Ban_Click(
        object sender,
        RoutedEventArgs e)
    {
        NavigationService?.Navigate(
            new BanMemberPage());
    }

    private void Unban_Click(
        object sender,
        RoutedEventArgs e)
    {
        NavigationService?.Navigate(
            new UnbanMemberPage());
    }

    private void Clear_Click(
        object sender,
        RoutedEventArgs e)
    {
        NavigationService?.Navigate(
            new ClearMessagesPage());
    }

    private void Lock_Click(
        object sender,
        RoutedEventArgs e)
    {
        NavigationService?.Navigate(
            new LockChannelPage());
    }

    private void Unlock_Click(
        object sender,
        RoutedEventArgs e)
    {
        NavigationService?.Navigate(
            new UnlockChannelPage());
    }


    // ================================================================
    // COMING SOON
    // ================================================================

    private static void ShowComingSoon(
        string action)
    {
        MessageBox.Show(
            $"{action} is not connected yet.",
            "Da Boyz Decisions",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
    }
}