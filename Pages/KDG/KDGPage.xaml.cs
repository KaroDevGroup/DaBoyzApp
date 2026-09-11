using System.Windows;
using System.Windows.Controls;
using DaBoyzApp.Services;

namespace DaBoyzApp.Pages;

public partial class KDGPage : Page
{
    public KDGPage()
    {
        InitializeComponent();

        Loaded += KDGPage_Loaded;
    }

    private void KDGPage_Loaded(
        object sender,
        RoutedEventArgs e)
    {
        CardAnimationService.Stagger(
            new[]
            {
                KDGBotButton,
                KDGAppButton,
                KDGTextureButton,
                KDGPostalButton
            });
    }

    private void KDGBot_Click(
        object sender,
        RoutedEventArgs e)
    {
        NavigationService?.Navigate(
            new KDGBotPage());
    }

    private void KDGApp_Click(
        object sender,
        RoutedEventArgs e)
    {
        NavigationService?.Navigate(
            new KDGAppPage());
    }

    private void KDGTexture_Click(
        object sender,
        RoutedEventArgs e)
    {
        NavigationService?.Navigate(
            new KDGTexturePage());
    }

    private void KDGPostal_Click(
        object sender,
        RoutedEventArgs e)
    {
        NavigationService?.Navigate(
            new KDGPostalPage());
    }
}