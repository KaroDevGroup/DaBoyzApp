using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class HelldiversPage : Page
    {
        public HelldiversPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new GamingPage());
        }

        private void InfoHub_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new InfoHubPage());
        }

        private void HelldiversMap_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new HelldiversMapPage());
        }
    }
}