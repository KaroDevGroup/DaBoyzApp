using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;

namespace DaBoyzApp.Pages
{
    public partial class InfoHubPage : Page
    {
        public InfoHubPage()
        {
            InitializeComponent();

            Loaded += InfoHubPage_Loaded;
        }

        private async void InfoHubPage_Loaded(
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

                await HelldiversInfoHubBrowser.EnsureCoreWebView2Async(
                    environment
                );

                HelldiversInfoHubBrowser.CoreWebView2.Navigate(
                    "https://democracy-hub.net/index.php"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Helldivers 2 Info Hub failed to load.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"HRESULT: 0x{ex.HResult:X8}",
                    "Da Boyz - Helldivers 2 Info Hub Error",
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