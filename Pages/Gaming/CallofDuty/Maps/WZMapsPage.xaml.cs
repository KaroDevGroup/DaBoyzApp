// KaroDevGroup
// Josh Karo

using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;

namespace DaBoyzApp.Pages
{
    public partial class WZMapsPage : Page
    {
        public WZMapsPage()
        {
            InitializeComponent();

            Loaded += WZMapsPage_Loaded;
        }

        private async void WZMapsPage_Loaded(
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

                await WZMapsBrowser.EnsureCoreWebView2Async(
                    environment
                );

                WZMapsBrowser.CoreWebView2.Navigate(
                    "https://wzhub.gg/map/warzone"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Call of Duty Loadouts failed to load.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"HRESULT: 0x{ex.HResult:X8}",
                    "Da Boyz - Call of Duty Loadouts Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private void BackButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            NavigationService?.Navigate(new CallofDutyPage());
        }
    }
}