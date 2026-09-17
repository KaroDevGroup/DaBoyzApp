// KaroDevGroup
// Josh Karo

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

        private void MinecraftSkins_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new MCSkinsPage());
        }

        private void MinecraftWebsite_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new MCWebsitePage());
        }
    }
}