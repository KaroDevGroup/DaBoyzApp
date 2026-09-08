using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class ShuroChiPage : Page
    {
        public ShuroChiPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new LastWishPage());
        }
    }
}