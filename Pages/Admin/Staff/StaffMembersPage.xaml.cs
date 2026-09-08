using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages;

public partial class StaffMembersPage : Page
{
    public StaffMembersPage()
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