using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class TaniksRebornPage : Page
    {
        public TaniksRebornPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new DeepStoneCryptPage());
        }
    }
}