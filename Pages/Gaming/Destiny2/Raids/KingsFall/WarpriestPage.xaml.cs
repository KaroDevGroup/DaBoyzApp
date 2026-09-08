using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class WarpriestPage : Page
    {
        public WarpriestPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new KingsFallPage());
        }
    }
}