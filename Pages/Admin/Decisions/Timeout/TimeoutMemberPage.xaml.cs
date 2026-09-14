// KaroDevGroup
// Josh Karo

using System.Windows;
using System.Windows.Controls;
using DaBoyzApp.Services;

namespace DaBoyzApp.Pages;

public partial class TimeoutMemberPage : Page
{
    public TimeoutMemberPage()
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

    private async void TimeoutButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        string memberId =
            MemberIdBox.Text.Trim();

        string duration =
            DurationBox.Text.Trim();

        string reason =
            ReasonBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(memberId))
        {
            StatusText.Text =
                "Please enter a Discord member ID.";

            MemberIdBox.Focus();

            return;
        }

        if (string.IsNullOrWhiteSpace(duration))
        {
            StatusText.Text =
                "Please enter a timeout duration.";

            DurationBox.Focus();

            return;
        }

        TimeoutButton.IsEnabled =
            false;

        TimeoutButton.Content =
            "SUBMITTING...";

        StatusText.Text =
            "Sending timeout request...";

        try
        {
            ModerationResult result =
                await ModerationService.TimeoutMemberAsync(
                    memberId,
                    duration,
                    reason);

            StatusText.Text =
                result.Message;

            if (result.Success)
            {
                MemberIdBox.Clear();
                DurationBox.Clear();
                ReasonBox.Clear();
            }
        }
        finally
        {
            TimeoutButton.IsEnabled =
                true;

            TimeoutButton.Content =
                "ISSUE TIMEOUT";
        }
    }
}