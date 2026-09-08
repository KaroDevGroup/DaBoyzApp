using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class DefeatConsecratedMindPage : Page
    {
        public DefeatConsecratedMindPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new GardenOfSalvationPage());
        }
    }
}