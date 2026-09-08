using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class VaultPage : Page
    {
        public VaultPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new LastWishPage());
        }
    }
}