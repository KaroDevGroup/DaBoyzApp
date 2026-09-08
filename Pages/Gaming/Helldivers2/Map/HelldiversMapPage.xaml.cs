using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;

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
                string userDataFolder =
                    Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData
                        ),
                        "DaBoyzApp",
                        "WebView2"
                    );

                Directory.CreateDirectory(userDataFolder);

                CoreWebView2Environment environment =
                    await CoreWebView2Environment.CreateAsync(
                        null,
                        userDataFolder
                    );

                await HelldiversMapBrowser.EnsureCoreWebView2Async(
                    environment
                );

                HelldiversMapBrowser.CoreWebView2.Navigate(
                    "https://hd2galaxy.com/"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Helldivers 2 Map failed to load.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"HRESULT: 0x{ex.HResult:X8}",
                    "Da Boyz - Helldivers 2 Map Error",
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