using System;
using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class RivalsTrackerPage : Page
    {
        public RivalsTrackerPage()
        {
            InitializeComponent();

            Loaded += RivalsTrackerPage_Loaded;
        }

        private async void RivalsTrackerPage_Loaded(
            object sender,
            RoutedEventArgs e)
        {
            try
            {
                await RivalsTrackerBrowser.EnsureCoreWebView2Async();

                RivalsTrackerBrowser.CoreWebView2.Navigate(
                    "https://tracker.gg/marvel-rivals"
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