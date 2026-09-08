using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class Rainbow6SiegePage : Page
    {
        public Rainbow6SiegePage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new GamingPage());
        }

        private void Maps_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new MapsPage());
        }

        private void SiegeTracker_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new SiegeTrackerPage());
        }
    }
}