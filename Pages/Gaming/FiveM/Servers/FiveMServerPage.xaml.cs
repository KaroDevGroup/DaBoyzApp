using System;
using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class FiveMServerPage : Page
    {
        public FiveMServerPage()
        {
            InitializeComponent();

            Loaded += FiveMServerPage_Loaded;
        }

        private async void FiveMServerPage_Loaded(
            object sender,
            RoutedEventArgs e)
        {
            try
            {
                await FiveMServerBrowser.EnsureCoreWebView2Async();

                FiveMServerBrowser.CoreWebView2.Navigate(
                    "https://servers.fivem.net/"
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
            NavigationService?.Navigate(new FiveMPage());
        }
    }
}