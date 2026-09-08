using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages;

public partial class DiscordCommandsPage : Page
{
    public DiscordCommandsPage()
    {
        InitializeComponent();
    }

    private void BackButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        if (Application.Current.MainWindow is MainWindow mainWindow)
        {
            mainWindow.NavigateToAdminDashboard();
        }
    }
}