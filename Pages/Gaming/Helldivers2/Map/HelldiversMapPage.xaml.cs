using System;
using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class HelldiversMapPage : Page
    {
        public HelldiversMapPage()
        {
            InitializeComponent();

            Loaded += HelldiversMapPage_Loaded;
        }

        private async void HelldiversMapPage_Loaded(
            object sender,
            RoutedEventArgs e)
        {
            try
            {
                await HelldiversMapBrowser.EnsureCoreWebView2Async();

                HelldiversMapBrowser.CoreWebView2.Navigate(
                    "https://hd2galaxy.com/"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Raid Report failed to load.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"HRESULT: 0x{ex.HResult:X8}",
                    "Da Boyz - Raid Report Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private void BackButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            NavigationService?.Navigate(new HelldiversPage());
        }
    }
}