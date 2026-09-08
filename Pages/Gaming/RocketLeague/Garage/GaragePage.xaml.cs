using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;

namespace DaBoyzApp.Pages
{
    public partial class GaragePage : Page
    {
        public GaragePage()
        {
            InitializeComponent();

            Loaded += GaragePage_Loaded;
        }

        private async void GaragePage_Loaded(
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

                await RocketLeagueBrowser.EnsureCoreWebView2Async(
                    environment
                );

                RocketLeagueBrowser.CoreWebView2.Navigate(
                    "https://rocket-league.com/news/rl-garage-on-windows"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Rocket League Garage failed to load.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"HRESULT: 0x{ex.HResult:X8}",
                    "Da Boyz - Rocket League Garage Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private void BackButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RocketLeaguePage());
        }
    }
}