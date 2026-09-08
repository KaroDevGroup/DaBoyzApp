using System;
using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class InfoHubPage : Page
    {
        public InfoHubPage()
        {
            InitializeComponent();

            Loaded += InfoHubPage_Loaded;
        }

        private async void InfoHubPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await HelldiversInfoHubBrowser.EnsureCoreWebView2Async();

                HelldiversInfoHubBrowser.CoreWebView2.Navigate(
                    "https://democracy-hub.net/index.php"
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
            NavigationService?.Navigate(new HelldiversPage());
        }
    }
}