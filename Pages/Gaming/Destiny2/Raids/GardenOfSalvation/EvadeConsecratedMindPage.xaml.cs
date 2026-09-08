using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class EvadeConsecratedMindPage : Page
    {
        public EvadeConsecratedMindPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new GardenOfSalvationPage());
        }
    }
}