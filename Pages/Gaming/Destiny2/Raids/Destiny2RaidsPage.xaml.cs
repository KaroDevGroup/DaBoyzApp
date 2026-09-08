using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class Destiny2RaidsPage : Page
    {
        public Destiny2RaidsPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Destiny2Page());
        }

        private void KingsFall_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new KingsFallPage());
        }

        private void SalvationsEdge_Click(object sender, RoutedEventArgs e)
        {
            // To do
        }

        private void RootOfNightmares_Click(object sender, RoutedEventArgs e)
        {
            // To do
        }

        private void CrotasEnd_Click(object sender, RoutedEventArgs e)
        {
            // To do
        }

        private void VowOfTheDisciple_Click(object sender, RoutedEventArgs e)
        {
            // To do
        }

        private void VaultOfGlass_Click(object sender, RoutedEventArgs e)
        {
            // To do
        }

        private void DeepStoneCrypt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new DeepStoneCryptPage());
        }

        private void GardenOfSalvation_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new GardenOfSalvationPage());
        }

        private void LastWish_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new LastWishPage());
        }

        private void DesertPerpetual_Click(object sender, RoutedEventArgs e)
        {
            // To DO
        }
    }
}