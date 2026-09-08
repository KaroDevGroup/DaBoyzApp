using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Web.WebView2.Core;

namespace DaBoyzApp.Controls
{
    public partial class YouTubePlayer : UserControl
    {
        public YouTubePlayer()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty VideoIdProperty =
            DependencyProperty.Register(
                nameof(VideoId),
                typeof(string),
                typeof(YouTubePlayer),
                new PropertyMetadata(string.Empty, OnVideoIdChanged));

        public string VideoId
        {
            get => (string)GetValue(VideoIdProperty);
            set => SetValue(VideoIdProperty, value);
        }

        private static async void OnVideoIdChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            if (d is YouTubePlayer player &&
                e.NewValue is string videoId &&
                !string.IsNullOrWhiteSpace(videoId))
            {
                await player.LoadVideo(videoId);
            }
        }

        private async System.Threading.Tasks.Task LoadVideo(string videoId)
        {
            try
            {
                string userDataFolder =
                    Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData
                        ),
                        "DaBoyzApp",
                        "WebView2"
                    );

                Directory.CreateDirectory(userDataFolder);

                CoreWebView2Environment environment =
                    await CoreWebView2Environment.CreateAsync(
                        null,
                        userDataFolder
                    );

                await Player.EnsureCoreWebView2Async(environment);

                Player.CoreWebView2.AddWebResourceRequestedFilter(
                    "https://www.youtube.com/*",
                    CoreWebView2WebResourceContext.All
                );

                Player.CoreWebView2.WebResourceRequested -=
                    CoreWebView2_WebResourceRequested;

                Player.CoreWebView2.WebResourceRequested +=
                    CoreWebView2_WebResourceRequested;

                Player.CoreWebView2.Navigate(
                    $"https://www.youtube.com/embed/{videoId}"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"YouTube player failed to load.\n\n" +
                    $"Error: {ex.Message}\n\n" +
                    $"HRESULT: 0x{ex.HResult:X8}",
                    "Da Boyz - YouTube Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        private void CoreWebView2_WebResourceRequested(
            object? sender,
            CoreWebView2WebResourceRequestedEventArgs e)
        {
            try
            {
                e.Request.Headers.SetHeader(
                    "Referer",
                    "https://daboyzapp.example/"
                );
            }
            catch
            {
                // Ignore requests where the header cannot be modified.
            }
        }
    }
}