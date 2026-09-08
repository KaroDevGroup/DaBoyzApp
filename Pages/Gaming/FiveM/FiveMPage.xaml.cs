using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class FiveMPage : Page
    {
        public FiveMPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new GamingPage());
        }

        private void CFX_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new CFXPage());
        }

        private void FiveMServers_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new FiveMServerPage());
        }
    }
}