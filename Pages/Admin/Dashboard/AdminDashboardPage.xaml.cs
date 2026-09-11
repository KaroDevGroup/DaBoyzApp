using System.Windows;
using System.Windows.Controls;
using DaBoyzApp.Services;

namespace DaBoyzApp.Pages;

public partial class AdminDashboardPage : Page
{
    public AdminDashboardPage()
    {
        InitializeComponent();

        Loaded += AdminDashboardPage_Loaded;
    }

    private void AdminDashboardPage_Loaded(
        object sender,
        RoutedEventArgs e)
    {
        CardAnimationService.Stagger(
            new[]
            {
                PunishmentSlateButton,
                DiscordCommandsButton,
                StaffMembersButton,
                RulesButton
            });
    }

    private void PunishmentSlate_Click(
        object sender,
        RoutedEventArgs e)
    {
        NavigationService?.Navigate(
            new PunishmentSlatePage());
    }

    private void DiscordCommands_Click(
        object sender,
        RoutedEventArgs e)
    {
        if (Application.Current.MainWindow
            is MainWindow mainWindow)
        {
            mainWindow.NavigateToDiscordCommands();
        }
    }

    private void StaffMembers_Click(
        object sender,
        RoutedEventArgs e)
    {
        if (Application.Current.MainWindow
            is MainWindow mainWindow)
        {
            mainWindow.NavigateToStaffMembers();
        }
    }

    private void Rules_Click(
        object sender,
        RoutedEventArgs e)
    {
        if (Application.Current.MainWindow
            is MainWindow mainWindow)
        {
            mainWindow.NavigateToRules();
        }
    }
}