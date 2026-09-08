using System;
using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class RaidReportPage : Page
    {
        public RaidReportPage()
        {
            InitializeComponent();

            Loaded += RaidReportPage_Loaded;
        }

        private async void RaidReportPage_Loaded(
            object sender,
            RoutedEventArgs e)
        {
            try
            {
                await RaidReportBrowser.EnsureCoreWebView2Async();

                RaidReportBrowser.CoreWebView2.Navigate(
                    "https://raid.report/"
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
            NavigationService?.Navigate(new Destiny2Page());
        }
    }
}