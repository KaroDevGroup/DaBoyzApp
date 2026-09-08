using System.Linq.Expressions;
using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages;

public partial class AdminDashboardPage : Page
{
public AdminDashboardPage()
{
InitializeComponent();
}

private void PunishmentSlate_Click(object sender, RoutedEventArgs e)
{
    NavigationService?.Navigate(new PunishmentSlatePage());        
}

private void DiscordCommands_Click(
    object sender,
    RoutedEventArgs e)
{
    if (Application.Current.MainWindow is MainWindow mainWindow)
    {
        mainWindow.NavigateToDiscordCommands();    
    }        
}

private void StaffMembers_Click(
    object sender,
    RoutedEventArgs e)
{
    if (Application.Current.MainWindow is MainWindow mainWindow)
    {
        mainWindow.NavigateToStaffMembers();        
    }        
}

private void Rules_Click(
    object sender,
    RoutedEventArgs e)
{
    if (Application.Current.MainWindow is MainWindow mainWindow)
    {
        mainWindow.NavigateToRules();        
    }        
}

}