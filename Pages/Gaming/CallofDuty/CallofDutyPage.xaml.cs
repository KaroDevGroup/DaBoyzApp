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
    }
}