using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class DaughtersPage : Page
    {
        public DaughtersPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new KingsFallPage());
        }
    }
}