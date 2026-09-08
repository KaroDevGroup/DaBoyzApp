using System;
using System.Windows;
using System.Windows.Controls;

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
                await MinecraftBrowser.EnsureCoreWebView2Async();

                MinecraftBrowser.CoreWebView2.Navigate(
                    "https://www.curseforge.com/minecraft"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Raid Report failed to load.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"HRESULT: 0x{ex.HResult:X8}",
                    "Da Boyz - Raid Report Error",
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