using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class RocketLeaguePage : Page
    {
        public RocketLeaguePage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new GamingPage());
        }

        private void Garage_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new GaragePage());
        }

        private void RocketTracker_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RocketTrackerPage());
        }
    }
}