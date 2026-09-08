using System;
using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class WiKiPage : Page
    {
        public WiKiPage()
        {
            InitializeComponent();

            Loaded += WiKiPage_Loaded;
        }

        private async void WiKiPage_Loaded(
            object sender,
            RoutedEventArgs e)
        {
            try
            {
                await RivalsWiKiBrowser.EnsureCoreWebView2Async();

                RivalsWiKiBrowser.CoreWebView2.Navigate(
                    "https://marvelrivals.gg/"
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
            NavigationService?.Navigate(new MarvelRivalsPage());
        }
    }
}