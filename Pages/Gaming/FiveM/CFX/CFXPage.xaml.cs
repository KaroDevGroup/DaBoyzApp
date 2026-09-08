using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;

namespace DaBoyzApp.Pages
{
    public partial class CFXPage : Page
    {
        public CFXPage()
        {
            InitializeComponent();

            Loaded += CFXPage_Loaded;
        }

        private async void CFXPage_Loaded(
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

                await CFXBrowser.EnsureCoreWebView2Async(
                    environment
                );

                CFXBrowser.CoreWebView2.Navigate(
                    "https://forum.cfx.re/"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"FiveM Cfx failed to load.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"HRESULT: 0x{ex.HResult:X8}",
                    "Da Boyz - FiveM Cfx Error",
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