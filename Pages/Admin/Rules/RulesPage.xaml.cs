using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages;

public partial class RulesPage : Page
{
    public RulesPage()
    {
        InitializeComponent();
    }


    // ================================================================
    // BACK BUTTON
    // ================================================================

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