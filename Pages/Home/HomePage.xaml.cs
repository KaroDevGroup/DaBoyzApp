using System.Windows;
using System.Windows.Controls;
using DaBoyzApp.Services;

namespace DaBoyzApp.Pages;

public partial class HomePage : Page
{
    public HomePage()
    {
        InitializeComponent();

        Loaded += HomePage_Loaded;
    }

    private void HomePage_Loaded(
        object sender,
        RoutedEventArgs e)
    {
        CardAnimationService.Stagger(
            new[]
            {
                GamingCardButton,
                MusicCardButton,
                PatchNotesCardButton,
                AdminCardButton
            });
    }

    private void GamingCard_Click(
        object sender,
        RoutedEventArgs e)
    {
        (Window.GetWindow(this) as MainWindow)?
            .NavigateToGaming();
    }

    private void MusicCard_Click(
        object sender,
        RoutedEventArgs e)
    {
        (Window.GetWindow(this) as MainWindow)?
            .NavigateToMusic();
    }

    private void PatchNotesCard_Click(
        object sender,
        RoutedEventArgs e)
    {
        (Window.GetWindow(this) as MainWindow)?
            .NavigateToPatchNotes();
    }

    private void AdminCard_Click(
        object sender,
        RoutedEventArgs e)
    {
        (Window.GetWindow(this) as MainWindow)?
            .NavigateToAdmin();
    }
}