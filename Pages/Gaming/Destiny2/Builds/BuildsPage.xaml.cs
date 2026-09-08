using System;
using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class BuildsPage : Page
    {
        public BuildsPage()
        {
            InitializeComponent();

            Loaded += BuildsPage_Loaded;
        }

        private async void BuildsPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await BuildsBrowser.EnsureCoreWebView2Async();

                BuildsBrowser.CoreWebView2.Navigate(
                    "https://mobalytics.gg/destiny-2/builds"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Mobalytics failed to load.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"HRESULT: 0x{ex.HResult:X8}",
                    "Da Boyz - Mobalytics Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Destiny2Page());
        }
    }
}