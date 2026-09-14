// KaroDevGroup
// Josh Karo

using System.Windows;
using System.Windows.Controls;
using DaBoyzApp.Services;

namespace DaBoyzApp.Pages;

public partial class KickMemberPage : Page
{
    public KickMemberPage()
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


    private async void KickButton_Click(
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


        KickButton.IsEnabled =
            false;

        KickButton.Content =
            "SUBMITTING...";

        StatusText.Text =
            "Sending kick request...";


        try
        {
            ModerationResult result =
                await ModerationService.KickMemberAsync(
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
            KickButton.IsEnabled =
                true;

            KickButton.Content =
                "KICK MEMBER";
        }
    }
}