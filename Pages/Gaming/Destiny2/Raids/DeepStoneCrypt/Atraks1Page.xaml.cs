using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class Atraks1Page : Page
    {
        public Atraks1Page()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new DeepStoneCryptPage());
        }
    }
}