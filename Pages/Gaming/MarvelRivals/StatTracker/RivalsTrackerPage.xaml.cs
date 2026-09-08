using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;

namespace DaBoyzApp.Pages
{
    public partial class RivalsTrackerPage : Page
    {
        public RivalsTrackerPage()
        {
            InitializeComponent();

            Loaded += RivalsTrackerPage_Loaded;
        }

        private async void RivalsTrackerPage_Loaded(
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

                await RivalsTrackerBrowser.EnsureCoreWebView2Async(
                    environment
                );

                RivalsTrackerBrowser.CoreWebView2.Navigate(
                    "https://tracker.gg/marvel-rivals"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Marvel Rivals Stat Tracker failed to load.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"HRESULT: 0x{ex.HResult:X8}",
                    "Da Boyz - Marvel Rivals Stat Tracker Error",
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