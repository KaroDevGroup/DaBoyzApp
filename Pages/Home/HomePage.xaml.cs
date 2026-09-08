using System.Windows;
using System.Windows.Controls;
using DaBoyzApp;

namespace DaBoyzApp.Pages;

public partial class HomePage : Page
{
    public HomePage()
    {
        InitializeComponent();
    }

    private void GamingCard_Click(object sender, RoutedEventArgs e)
    {
        NavigateTo("Gaming");
    }

    private void MusicCard_Click(object sender, RoutedEventArgs e)
    {
        NavigateTo("Music");
    }

    private void PatchNotesCard_Click(object sender, RoutedEventArgs e)
    {
        NavigateTo("PatchNotes");
    }

    private void AdminCard_Click(object sender, RoutedEventArgs e)
    {
        NavigateTo("Admin");
    }

    private void NavigateTo(string page)
    {
        if (Application.Current.MainWindow is MainWindow mainWindow)
        {
            switch (page)
            {
                case "Gaming":
                    mainWindow.NavigateToGaming();
                    break;

                case "Music":
                    mainWindow.NavigateToMusic();
                    break;

                case "PatchNotes":
                    mainWindow.NavigateToPatchNotes();
                    break;

                case "Admin":
                    mainWindow.NavigateToAdmin();
                    break;
            }
        }
    }
}