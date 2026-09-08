using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;

namespace DaBoyzApp.Pages
{
    public partial class MapsPage : Page
    {
        public MapsPage()
        {
            InitializeComponent();

            Loaded += MapsPage_Loaded;
        }

        private async void MapsPage_Loaded(
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

                await MapsBrowser.EnsureCoreWebView2Async(
                    environment
                );

                MapsBrowser.CoreWebView2.Navigate(
                    "https://www.ubisoft.com/en-us/game/rainbow-six/siege/game-info/maps"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Rainbow Six Siege Maps failed to load.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"HRESULT: 0x{ex.HResult:X8}",
                    "Da Boyz - Rainbow Six Siege Maps Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private void BackButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Rainbow6SiegePage());
        }
    }
}