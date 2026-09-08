using System;
using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class LightGGPage : Page
    {
        public LightGGPage()
        {
            InitializeComponent();

            Loaded += LightGGPage_Loaded;
        }

        private async void LightGGPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await LightGGBrowser.EnsureCoreWebView2Async();

                LightGGBrowser.CoreWebView2.Navigate(
                    "https://www.light.gg/"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Light.gg failed to load.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"HRESULT: 0x{ex.HResult:X8}",
                    "Da Boyz - Light.gg Error",
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