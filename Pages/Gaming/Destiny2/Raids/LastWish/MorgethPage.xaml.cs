using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class MorgethPage : Page
    {
        public MorgethPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new LastWishPage());
        }
    }
}