using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;

namespace DaBoyzApp.Pages
{
    public partial class RocketTrackerPage : Page
    {
        public RocketTrackerPage()
        {
            InitializeComponent();

            Loaded += RocketTrackerPage_Loaded;
        }

        private async void RocketTrackerPage_Loaded(
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

                await RocketTrackerBrowser.EnsureCoreWebView2Async(
                    environment
                );

                RocketTrackerBrowser.CoreWebView2.Navigate(
                    "https://rocketleague.tracker.network/"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Rocket League Stat Tracker failed to load.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"HRESULT: 0x{ex.HResult:X8}",
                    "Da Boyz - Rocket League Stat Tracker Error",
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