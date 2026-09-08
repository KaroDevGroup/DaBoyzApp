using System;
using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class StatTrackerPage : Page
    {
        public StatTrackerPage()
        {
            InitializeComponent();

            Loaded += StatTrackerPage_Loaded;
        }

        private async void StatTrackerPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await StatTrackerBrowser.EnsureCoreWebView2Async();

                StatTrackerBrowser.CoreWebView2.Navigate(
                    "https://tracker.gg/warzone"
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
            NavigationService?.Navigate(new CallofDutyPage());
        }
    }
}