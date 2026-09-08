using System;
using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class SiegeTrackerPage : Page
    {
        public SiegeTrackerPage()
        {
            InitializeComponent();

            Loaded += SiegeTrackerPage_Loaded;
        }

        private async void SiegeTrackerPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await SiegeTrackerBrowser.EnsureCoreWebView2Async();

                SiegeTrackerBrowser.CoreWebView2.Navigate(
                    "https://r6.tracker.network/"
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