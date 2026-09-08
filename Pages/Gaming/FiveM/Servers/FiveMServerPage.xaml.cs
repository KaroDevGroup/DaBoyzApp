using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;

namespace DaBoyzApp.Pages
{
    public partial class FiveMServerPage : Page
    {
        public FiveMServerPage()
        {
            InitializeComponent();

            Loaded += FiveMServerPage_Loaded;
        }

        private async void FiveMServerPage_Loaded(
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

                await FiveMServerBrowser.EnsureCoreWebView2Async(
                    environment
                );

                FiveMServerBrowser.CoreWebView2.Navigate(
                    "https://servers.fivem.net/"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"FiveM Server List failed to load.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"HRESULT: 0x{ex.HResult:X8}",
                    "Da Boyz - FiveM Server List Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private void BackButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            NavigationService?.Navigate(new FiveMPage());
        }
    }
}