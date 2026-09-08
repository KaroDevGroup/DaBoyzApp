using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class DeepStoneCryptPage : Page
    {
        public DeepStoneCryptPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Destiny2RaidsPage());
        }

        private void CryptSecurity_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new CryptSecurityPage());
        }

        private void Atraks1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Atraks1Page());
        }

        private void TaniksReborn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TaniksRebornPage());
        }

        private void TaniksAbomination_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TaniksAbominationPage());
        }
    }
}