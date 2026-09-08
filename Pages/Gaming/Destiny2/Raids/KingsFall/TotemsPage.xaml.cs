using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class TotemsPage : Page
    {
        public TotemsPage()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new KingsFallPage());
        }
    }
}