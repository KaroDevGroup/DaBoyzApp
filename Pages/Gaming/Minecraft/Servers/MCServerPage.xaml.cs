using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;

namespace DaBoyzApp.Pages
{
    public partial class MCServerPage : Page
    {
        public MCServerPage()
        {
            InitializeComponent();

            Loaded += MCServerPage_Loaded;
        }

        private async void MCServerPage_Loaded(
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

                await MinecraftServerBrowser.EnsureCoreWebView2Async(
                    environment
                );

                MinecraftServerBrowser.CoreWebView2.Navigate(
                    "https://minecraft-server-list.com/"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Minecraft Servers failed to load.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"HRESULT: 0x{ex.HResult:X8}",
                    "Da Boyz - Minecraft Servers Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private void BackButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            NavigationService?.Navigate(new MinecraftPage());
        }
    }
}