// KaroDevGroup
// Josh Karo

using System.Windows;
using System.Windows.Controls;
using DaBoyzApp.Services;

namespace DaBoyzApp.Pages;

public partial class LockChannelPage : Page
{
    public LockChannelPage()
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

    private async void LockButton_Click(
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

        LockButton.IsEnabled =
            false;

        LockButton.Content =
            "SUBMITTING...";

        StatusText.Text =
            "Sending lock request...";

        try
        {
            ModerationResult result =
                await ModerationService.LockChannelAsync(
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
            LockButton.IsEnabled =
                true;

            LockButton.Content =
                "LOCK CHANNEL";
        }
    }
}