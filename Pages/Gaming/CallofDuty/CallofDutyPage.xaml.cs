// KaroDevGroup
// Josh Karo

using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class CallofDutyPage : Page
    {
        public CallofDutyPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new GamingPage());
        }

        private void Loadouts_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new LoadoutsPage());
        }

        private void StatTracker_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new StatTrackerPage());
        }

        private void WarzoneMaps_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new WZMapsPage());
        }

        private void WarzoneWebsite_Click(object sender,RoutedEventArgs e)
        {
            NavigationService?.Navigate(new WZWebsitePage());
        }
    }
}