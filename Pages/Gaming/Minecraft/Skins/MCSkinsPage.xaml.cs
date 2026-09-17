// KaroDevGroup
// Josh Karo

using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;

namespace DaBoyzApp.Pages
{
    public partial class MCSkinsPage : Page
    {
        public MCSkinsPage()
        {
            InitializeComponent();

            Loaded += MCSkinsPage_Loaded;
        }

        private async void MCSkinsPage_Loaded(
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

                await MinecraftSkinsBrowser.EnsureCoreWebView2Async(
                    environment
                );

                MinecraftSkinsBrowser.CoreWebView2.Navigate(
                    "https://skinmc.net/skin-editor"
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