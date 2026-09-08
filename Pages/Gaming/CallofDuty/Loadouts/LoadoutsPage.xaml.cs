using System;
using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class LoadoutsPage : Page
    {
        public LoadoutsPage()
        {
            InitializeComponent();

            Loaded += LoadoutsPage_Loaded;
        }

        private async void LoadoutsPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await LoadoutsBrowser.EnsureCoreWebView2Async();

                LoadoutsBrowser.CoreWebView2.Navigate(
                    "https://wzstats.gg/"
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