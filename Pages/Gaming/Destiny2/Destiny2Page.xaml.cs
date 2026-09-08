using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class Destiny2Page : Page
    {
        public Destiny2Page()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new GamingPage());
        }

        private void Raids_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Destiny2RaidsPage());
        }

        private void RaidReport_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RaidReportPage());
        }

        private void LightGG_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new LightGGPage());
        }

        private void Builds_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new BuildsPage());
        }
    }
}