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


    // =========================================================
    // LOAD REMEMBERED LOGIN
    // =========================================================

    private void LoadRememberedCredentials()
    {
        var credentials =
            AdminAuthService.LoadCredentials();

        if (credentials == null)
        {
            return;
        }

        UsernameBox.Text =
            credentials.Value.Username;

        PasswordBox.Password =
            credentials.Value.Password;

        RememberMeCheckBox.IsChecked =
            true;

        StatusText.Text =
            "Remembered login found.";
    }


    // =========================================================
    // SIGN IN
    // =========================================================

    private void SignInButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        string username =
            UsernameBox.Text.Trim();

        string password =
            PasswordBox.Password;


        // =====================================================
        // VALIDATE INPUT
        // =====================================================

        if (string.IsNullOrWhiteSpace(username))
        {
            StatusText.Text =
                "Please enter your username.";

            UsernameBox.Focus();

            return;
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            StatusText.Text =
                "Please enter your password.";

            PasswordBox.Focus();

            return;
        }


        // =====================================================
        // AUTHENTICATE
        // =====================================================

        if (IsValidAdmin(
                username,
                password))
        {
            StatusText.Text =
                "Authentication successful.";


            // =================================================
            // REMEMBER ME
            // =================================================

            if (RememberMeCheckBox.IsChecked == true)
            {
                AdminAuthService.SaveCredentials(
                    username,
                    password);
            }
            else
            {
                AdminAuthService.ClearCredentials();
            }


            // =================================================
            // OPEN ADMIN DASHBOARD
            // =================================================

            NavigationService?.Navigate(
                new AdminDashboardPage());

            return;
        }


        // =====================================================
        // INVALID LOGIN
        // =====================================================

        StatusText.Text =
            "Invalid username or password.";

        PasswordBox.Clear();
        PasswordBox.Focus();
    }


    // =========================================================
    // ADMIN AUTHENTICATION
    // =========================================================

    private static bool IsValidAdmin(
        string username,
        string password)
    {
        // MASTER ACCOUNT

        if (username == "admin" &&
            password == "admin123")
        {
            return true;
        }


        // GAVIN

        if (username == "Jesusisking" &&
            password == "hailhitler9")
        {
            return true;
        }


        // JESS

        if (username == "MrsKaro" &&
            password == "Karo0325")
        {
            return true;
        }


        // REED

        if (username == "Rugerwhite123" &&
            password == "Greenwave#1")
        {
            return true;
        }


        // RUDY

        if (username == "Zen" &&
            password == "zeniseverything")
        {
            return true;
        }


        // GAGE

        if (username == "Dizzy.kco" &&
            password == "Cumshooter67")
        {
            return true;
        }


        return false;
    }
}