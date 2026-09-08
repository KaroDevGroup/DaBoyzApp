using System.Windows.Controls;
using System.Windows;

namespace DaBoyzApp.Pages;

public partial class PunishmentSlatePage : Page
{
    public PunishmentSlatePage()
    {
        InitializeComponent();
    }

    private void BackButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        NavigationService?.Navigate(
            new AdminDashboardPage());
    }
}