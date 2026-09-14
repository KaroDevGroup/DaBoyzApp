// KaroDevGroup
// Josh Karo

using System.Windows;
using System.Windows.Controls;
using DaBoyzApp.Services;

namespace DaBoyzApp.Pages;

public partial class AdminPage : Page
{
    public AdminPage()
    {
        InitializeComponent();

        LoadRememberedCredentials();
    }

    private void LoadRememberedCredentials()
    {
        var credentials =
            AdminAuthService.LoadCredentials();

        if (credentials == null)
        {
            return;
        }

        EmailBox.Text =
            credentials.Value.Username;

        PasswordBox.Password =
            credentials.Value.Password;

        RememberMeCheckBox.IsChecked =
            true;

        StatusText.Text =
            "Remembered login found.";
    }

    private async void SignInButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        string email =
            EmailBox.Text.Trim();

        string password =
            PasswordBox.Password;

        if (string.IsNullOrWhiteSpace(
                email))
        {
            StatusText.Text =
                "Please enter your email.";

            EmailBox.Focus();

            return;
        }

        if (string.IsNullOrWhiteSpace(
                password))
        {
            StatusText.Text =
                "Please enter your password.";

            PasswordBox.Focus();

            return;
        }

        SignInButton.IsEnabled =
            false;

        SignInButton.Content =
            "SIGNING IN...";

        StatusText.Text =
            "Authenticating...";


        try
        {

            AuthResult result =
                await SupabaseAuthService.SignInAsync(
                    email,
                    password);


            if (!result.Success)
            {
                StatusText.Text =
                    result.Message;

                PasswordBox.Focus();

                return;
            }

            if (RememberMeCheckBox.IsChecked ==
                true)
            {
                AdminAuthService.SaveCredentials(
                    email,
                    password);
            }
            else
            {
                AdminAuthService.ClearCredentials();
            }

            StatusText.Text =
                result.Message;

            NavigationService?.Navigate(
                new AdminDashboardPage());
        }
        catch (Exception ex)
        {
            SupabaseAuthService.ClearSession();

            StatusText.Text =
                $"Sign-in failed: {ex.Message}";
        }
        finally
        {
            SignInButton.IsEnabled =
                true;

            SignInButton.Content =
                "SIGN IN";
        }
    }
}