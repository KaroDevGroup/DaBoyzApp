using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;

namespace DaBoyzApp.Pages
{
    public partial class WiKiPage : Page
    {
        public WiKiPage()
        {
            InitializeComponent();

            Loaded += WiKiPage_Loaded;
        }

        private async void WiKiPage_Loaded(
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

                await RivalsWiKiBrowser.EnsureCoreWebView2Async(
                    environment
                );

                RivalsWiKiBrowser.CoreWebView2.Navigate(
                    "https://marvelrivals.gg/"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Marvel Rivals Wiki failed to load.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"HRESULT: 0x{ex.HResult:X8}",
                    "Da Boyz - Marvel Rivals Wiki Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private void BackButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            NavigationService?.Navigate(new MarvelRivalsPage());
        }
    }
}