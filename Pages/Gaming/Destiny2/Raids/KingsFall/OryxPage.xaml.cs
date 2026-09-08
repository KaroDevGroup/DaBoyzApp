using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class OryxPage : Page
    {
        public OryxPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new KingsFallPage());
        }
    }
}