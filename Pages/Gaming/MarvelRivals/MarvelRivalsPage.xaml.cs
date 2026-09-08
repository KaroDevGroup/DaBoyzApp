using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class MarvelRivalsPage : Page
    {
        public MarvelRivalsPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new GamingPage());
        }

        private void WiKi_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new WiKiPage());
        }

        private void RivalsTracker_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RivalsTrackerPage());
        }
    }
}