using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class DefeatSanctifiedMindPage : Page
    {
        public DefeatSanctifiedMindPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new GardenOfSalvationPage());
        }
    }
}