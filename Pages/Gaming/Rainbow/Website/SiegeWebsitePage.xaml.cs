// KaroDevGroup
// Josh Karo

using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;

namespace DaBoyzApp.Pages
{
    public partial class SiegeWebsitePage : Page
    {
        public SiegeWebsitePage()
        {
            InitializeComponent();

            Loaded += SiegeWebsitePage_Loaded;
        }

        private async void SiegeWebsitePage_Loaded(
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

                await SiegeWebsiteBrowser.EnsureCoreWebView2Async(
                    environment
                );

                SiegeWebsiteBrowser.CoreWebView2.Navigate(
                    "https://www.ubisoft.com/en-us/game/rainbow-six/siege"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Rainbow Six Siege Stat Tracker failed to load.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"HRESULT: 0x{ex.HResult:X8}",
                    "Da Boyz - Rainbow Six Siege Stat Tracker Error",
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