using System;
using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages
{
    public partial class CFXPage : Page
    {
        public CFXPage()
        {
            InitializeComponent();

            Loaded += CFXPage_Loaded;
        }

        private async void CFXPage_Loaded(
            object sender,
            RoutedEventArgs e)
        {
            try
            {
                await CFXBrowser.EnsureCoreWebView2Async();

                CFXBrowser.CoreWebView2.Navigate(
                    "https://forum.cfx.re/"
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