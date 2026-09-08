using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;

namespace DaBoyzApp.Pages
{
    public partial class MCModsPage : Page
    {
        public MCModsPage()
        {
            InitializeComponent();

            Loaded += MCModsPage_Loaded;
        }

        private async void MCModsPage_Loaded(
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

                await MinecraftBrowser.EnsureCoreWebView2Async(
                    environment
                );

                MinecraftBrowser.CoreWebView2.Navigate(
                    "https://www.curseforge.com/minecraft"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Minecraft Mods failed to load.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"HRESULT: 0x{ex.HResult:X8}",
                    "Da Boyz - Minecraft Mods Error",
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