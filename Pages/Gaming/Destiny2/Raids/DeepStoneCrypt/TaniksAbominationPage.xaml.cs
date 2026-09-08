using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class TaniksAbominationPage : Page
    {
        public TaniksAbominationPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new DeepStoneCryptPage());
        }
    }
}