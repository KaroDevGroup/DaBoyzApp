// KaroDevGroup
// Josh Karo

using System.Windows;
using System.Windows.Controls;
using DaBoyzApp.Services;

namespace DaBoyzApp.Pages;

public partial class BanMemberPage : Page
{
    public BanMemberPage()
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


    private async void BanButton_Click(
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


        BanButton.IsEnabled =
            false;

        BanButton.Content =
            "SUBMITTING...";

        StatusText.Text =
            "Sending ban request...";


        try
        {
            ModerationResult result =
                await ModerationService.BanMemberAsync(
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
            BanButton.IsEnabled =
                true;

            BanButton.Content =
                "BAN MEMBER";
        }
    }
}