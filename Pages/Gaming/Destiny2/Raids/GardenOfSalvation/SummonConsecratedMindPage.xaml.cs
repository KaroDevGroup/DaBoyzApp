using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class SummonConsecratedMindPage : Page
    {
        public SummonConsecratedMindPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new GardenOfSalvationPage());
        }
    }
}