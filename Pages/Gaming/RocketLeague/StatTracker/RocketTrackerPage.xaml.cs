using System;
using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class RocketTrackerPage : Page
    {
        public RocketTrackerPage()
        {
            InitializeComponent();

            Loaded += RocketTrackerPage_Loaded;
        }

        private async void RocketTrackerPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await RocketTrackerBrowser.EnsureCoreWebView2Async();

                RocketTrackerBrowser.CoreWebView2.Navigate(
                    "https://rocketleague.tracker.network/"
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