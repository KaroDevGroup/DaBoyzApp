using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class KingsFallPage : Page
    {
        public KingsFallPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Destiny2RaidsPage());
        }

        private void Totems_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new TotemsPage());
        }

        private void Warpriest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new WarpriestPage());
        }

        private void Golgoroth_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new GolgorothPage());
        }

        private void Daughters_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new DaughtersPage());
        }

        private void Oryx_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new OryxPage());
        }
    }
}