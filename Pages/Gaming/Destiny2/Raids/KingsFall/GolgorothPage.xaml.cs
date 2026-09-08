using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class GolgorothPage : Page
    {
        public GolgorothPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new KingsFallPage());
        }
    }
}