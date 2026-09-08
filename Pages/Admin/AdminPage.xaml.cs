using System.Windows;
using System.Windows.Controls;

namespace DaBoyzApp.Pages;

public partial class AdminPage : Page
{
    public AdminPage()
    {
        InitializeComponent();
    }

    private void SignInButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        string username = UsernameBox.Text.Trim();
        string password = PasswordBox.Password;

        // =========================================================
        // VALIDATE INPUT
        // =========================================================

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


        // =========================================================
        // TEMPORARY DEVELOPMENT LOGIN
        // =========================================================

        // MASTER ACCOUNT
        if (username == "admin" &&
            password == "admin123")
        {
            StatusText.Text =
                "Authentication successful.";

            NavigationService?.Navigate(
                new AdminDashboardPage());

            return;
        }

        // GAVIN
        if (username == "Jesusisking" &&
            password == "hailhitler9")
        {
            StatusText.Text =
                "Authentication successful.";
            
            NavigationService?.Navigate(
                new AdminDashboardPage());

            return;
        }

        // JESS
        if (username == "MrsKaro" &&
            password == "Karo0325")
        {
            StatusText.Text = 
                "Authentication successful.";

            NavigationService?.Navigate(
                new AdminDashboardPage());

            return;
        }

        // REED
        if (username == "Rugerwhite123" &&
            password == "Greenwave#1")
        {
            StatusText.Text =
                "Authentication successful.";

            NavigationService?.Navigate(
                new AdminDashboardPage());

            return;
        }

        // RUDY
        if (username == "Zen" &&
            password == "zeniseverything")
        {
            StatusText.Text =
                "Authentication successful.";
            
            NavigationService?.Navigate(
                new AdminDashboardPage());

            return;
        }

        // GAGE
        if (username == "Dizzy.kco" &&
            password == "Cumshooter67")
        {
            StatusText.Text =
                "Authentication successful.";
            
            NavigationService?.Navigate(
                new AdminDashboardPage());

            return;
        }

        // =========================================================
        // INVALID LOGIN
        // =========================================================

        StatusText.Text =
            "Invalid username or password.";

        PasswordBox.Clear();
        PasswordBox.Focus();
    }
}