using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class CryptSecurityPage : Page
    {
        public CryptSecurityPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new DeepStoneCryptPage());
        }
    }
}