using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class LastWishPage : Page
    {
        public LastWishPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Destiny2RaidsPage());
        }

        private void Kalli_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new KalliPage());
        }

        private void ShuroChi_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new ShuroChiPage());
        }

        private void Morgeth_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new MorgethPage());
        }

        private void Vault_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new VaultPage());
        }

        private void Riven_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RivenPage());
        }

        private void Queenswalk_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new QueenswalkPage());
        }
    }
}