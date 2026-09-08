using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class MinecraftPage : Page
    {
        public MinecraftPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new GamingPage());
        }

        private void MinecraftMods_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new MCModsPage());
        }

        private void MinecraftServers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new MCServerPage());
        }
    }
}