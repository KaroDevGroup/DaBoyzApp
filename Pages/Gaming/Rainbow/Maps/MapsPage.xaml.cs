using System;
using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class MapsPage : Page
    {
        public MapsPage()
        {
            InitializeComponent();

            Loaded += MapsPage_Loaded;
        }

        private async void MapsPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await MapsBrowser.EnsureCoreWebView2Async();

                MapsBrowser.CoreWebView2.Navigate(
                    "https://www.ubisoft.com/en-us/game/rainbow-six/siege/game-info/maps"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Mobalytics failed to load.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"HRESULT: 0x{ex.HResult:X8}",
                    "Da Boyz - Mobalytics Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new Rainbow6SiegePage());
        }
    }
}