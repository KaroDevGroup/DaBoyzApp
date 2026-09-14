// KaroDevGroup
// Josh Karo

using System.Windows;
using System.Windows.Controls;
using DaBoyzApp.Services;

namespace DaBoyzApp.Pages;

public partial class ClearMessagesPage : Page
{
    public ClearMessagesPage()
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

    private async void ClearButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        string channelId =
            ChannelIdBox.Text.Trim();

        string amountText =
            AmountBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(channelId))
        {
            StatusText.Text =
                "Please enter a Discord channel ID.";

            ChannelIdBox.Focus();

            return;
        }

        if (!int.TryParse(
                amountText,
                out int amount))
        {
            StatusText.Text =
                "Please enter a valid message amount.";

            AmountBox.Focus();

            return;
        }

        if (amount < 1 || amount > 100)
        {
            StatusText.Text =
                "Message amount must be between 1 and 100.";

            AmountBox.Focus();

            return;
        }

        ClearButton.IsEnabled =
            false;

        ClearButton.Content =
            "SUBMITTING...";

        StatusText.Text =
            "Sending clear request...";

        try
        {
            ModerationResult result =
                await ModerationService.ClearMessagesAsync(
                    channelId,
                    amount);

            StatusText.Text =
                result.Message;


            if (result.Success)
            {
                ChannelIdBox.Clear();
                AmountBox.Clear();
            }
        }
        finally
        {
            ClearButton.IsEnabled =
                true;

            ClearButton.Content =
                "CLEAR MESSAGES";
        }
    }
}