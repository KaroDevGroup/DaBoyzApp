using System;
using System.Windows;
using System.Windows.Controls;

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
                await MinecraftServerBrowser.EnsureCoreWebView2Async();

                MinecraftServerBrowser.CoreWebView2.Navigate(
                    "https://minecraft-server-list.com/"
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