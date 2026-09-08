using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class GardenOfSalvationPage : Page
    {
        public GardenOfSalvationPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Destiny2RaidsPage());
        }

        private void EvadeConsecratedMind_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new EvadeConsecratedMindPage());
        }

        private void SummonConsecratedMind_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new SummonConsecratedMindPage());
        }

        private void DefeatConsecratedMind_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new DefeatConsecratedMindPage());
        }

        private void DefeatSanctifiedMind_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new DefeatSanctifiedMindPage());
        }
    }
}