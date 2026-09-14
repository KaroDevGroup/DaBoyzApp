// KaroDevGroup
// Josh Karo

using System.Windows;
using System.Windows.Controls;
using DaBoyzApp.Services;

namespace DaBoyzApp.Pages;

public partial class WarnMemberPage : Page
{
    public WarnMemberPage()
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
    private async void WarnButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        string memberId =
            MemberIdBox.Text.Trim();

        string reason =
            ReasonBox.Text.Trim();

        if (string.IsNullOrWhiteSpace(memberId))
        {
            StatusText.Text =
                "Please enter a Discord member ID.";

            MemberIdBox.Focus();

            return;
        }

        WarnButton.IsEnabled =
            false;

        WarnButton.Content =
            "SUBMITTING...";

        StatusText.Text =
            "Sending warning request...";

        try
        {
            ModerationResult result =
                await ModerationService.WarnMemberAsync(
                    memberId,
                    reason);

            StatusText.Text =
                result.Message;

            if (result.Success)
            {
                MemberIdBox.Clear();
                ReasonBox.Clear();
            }
        }
        finally
        {
            WarnButton.IsEnabled =
                true;

            WarnButton.Content =
                "ISSUE WARNING";
        }
    }
}