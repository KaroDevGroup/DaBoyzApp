// KaroDevGroup
// Josh Karo

using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;

namespace DaBoyzApp.Pages
{
    public partial class MCWebsitePage : Page
    {
        public MCWebsitePage()
        {
            InitializeComponent();

            Loaded += MCWebsitePage_Loaded;
        }

        private async void MCWebsitePage_Loaded(
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

                await MinecraftWebsiteBrowser.EnsureCoreWebView2Async(
                    environment
                );

                MinecraftWebsiteBrowser.CoreWebView2.Navigate(
                    "https://www.minecraft.net/en-us"
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