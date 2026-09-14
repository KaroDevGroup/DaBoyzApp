// KaroDevGroup
// Josh Karo

using System.Windows;
using System.Windows.Controls;
using DaBoyzApp.Services;

namespace DaBoyzApp.Pages;

public partial class UnlockChannelPage : Page
{
    public UnlockChannelPage()
    {
        InitializeComponent();
    }

    private void BackButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        NavigationService?.Navigate(
            new DecisionsPage());
    }

    private async void UnlockButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        string channelId =
            ChannelIdBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(channelId))
        {
            StatusText.Text =
                "Please enter a Discord channel ID.";

            ChannelIdBox.Focus();

            return;
        }

        UnlockButton.IsEnabled =
            false;

        UnlockButton.Content =
            "SUBMITTING...";

        StatusText.Text =
            "Sending unlock request...";

        try
        {
            ModerationResult result =
                await ModerationService.UnlockChannelAsync(
                    channelId);

            StatusText.Text =
                result.Message;

            if (result.Success)
            {
                ChannelIdBox.Clear();
            }
        }
        finally
        {
            UnlockButton.IsEnabled =
                true;

            UnlockButton.Content =
                "UNLOCK CHANNEL";
        }
    }
}