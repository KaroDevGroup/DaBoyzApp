using System;
using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class GaragePage : Page
    {
        public GaragePage()
        {
            InitializeComponent();

            Loaded += GaragePage_Loaded;
        }

        private async void GaragePage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await RocketLeagueBrowser.EnsureCoreWebView2Async();

                RocketLeagueBrowser.CoreWebView2.Navigate(
                    "https://rocket-league.com/news/rl-garage-on-windows"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Light.gg failed to load.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"HRESULT: 0x{ex.HResult:X8}",
                    "Da Boyz - Light.gg Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RocketLeaguePage());
        }
    }
}