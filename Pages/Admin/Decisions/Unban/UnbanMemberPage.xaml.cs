// KaroDevGroup
// Josh Karo

using System.Windows;
using System.Windows.Controls;
using DaBoyzApp.Services;

namespace DaBoyzApp.Pages;

public partial class UnbanMemberPage : Page
{
    public UnbanMemberPage()
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


    private async void UnbanButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        string userId =
            UserIdBox.Text.Trim();

        string reason =
            ReasonBox.Text.Trim();


        if (string.IsNullOrWhiteSpace(userId))
        {
            StatusText.Text =
                "Please enter a Discord user ID.";

            UserIdBox.Focus();

            return;
        }


        UnbanButton.IsEnabled =
            false;

        UnbanButton.Content =
            "SUBMITTING...";

        StatusText.Text =
            "Sending unban request...";


        try
        {
            ModerationResult result =
                await ModerationService.UnbanMemberAsync(
                    userId,
                    reason);


            StatusText.Text =
                result.Message;


            if (result.Success)
            {
                UserIdBox.Clear();
                ReasonBox.Clear();
            }
        }
        finally
        {
            UnbanButton.IsEnabled =
                true;

            UnbanButton.Content =
                "UNBAN MEMBER";
        }
    }
}