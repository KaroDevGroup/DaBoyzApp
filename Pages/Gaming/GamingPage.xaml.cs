// KaroDevGroup
// Josh Karo

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace DaBoyzApp.Pages;

public partial class GamingPage : Page
{
    private readonly (Button Button, string Name)[] gameButtons;

    public GamingPage()
    {
        InitializeComponent();

        gameButtons =
        [
            (Destiny2Button, "destiny 2"),
            (MinecraftButton, "minecraft"),
            (CallofDutyButton, "call of duty"),
            (FiveMButton, "fivem"),
            (Rainbow6SiegeButton, "rainbow six siege"),
            (RocketLeagueButton, "rocket league"),
            (HelldiversButton, "helldivers 2"),
            (MarvelRivalsButton, "marvel rivals")
        ];

        UpdateGameFilter();

        Loaded += GamingPage_Loaded;
    }

    private void GamingPage_Loaded(object sender, RoutedEventArgs e)
    {
        AnimateGameCards();
    }

    private void AnimateGameCards()
    {
        int index = 0;

        foreach ((Button button, string _) in gameButtons)
        {
            button.Opacity = 0;

            TranslateTransform transform =
                new TranslateTransform(0, 20);

            button.RenderTransform = transform;

            DoubleAnimation opacityAnimation =
                new DoubleAnimation
                {
                    From = 0,
                    To = 1,
                    Duration = TimeSpan.FromMilliseconds(500),
                    BeginTime = TimeSpan.FromMilliseconds(index * 100),
                    EasingFunction =
                        new CubicEase
                        {
                            EasingMode = EasingMode.EaseOut
                        }
                };

            DoubleAnimation slideAnimation =
                new DoubleAnimation
                {
                    From = 20,
                    To = 0,
                    Duration = TimeSpan.FromMilliseconds(500),
                    BeginTime = TimeSpan.FromMilliseconds(index * 100),
                    EasingFunction =
                        new CubicEase
                        {
                            EasingMode = EasingMode.EaseOut
                        }
                };

            button.BeginAnimation(
                UIElement.OpacityProperty,
                opacityAnimation);

            transform.BeginAnimation(
                TranslateTransform.YProperty,
                slideAnimation);

            index++;
        }
    }

    private void SearchBox_TextChanged(
        object sender,
        TextChangedEventArgs e)
    {
        UpdateGameFilter();
    }

    private void UpdateGameFilter()
    {
        string searchText = SearchBox.Text.Trim();

        SearchPlaceholder.Visibility =
            string.IsNullOrEmpty(searchText)
                ? Visibility.Visible
                : Visibility.Collapsed;

        foreach ((Button button, string name) in gameButtons)
        {
            button.Visibility =
                string.IsNullOrEmpty(searchText)
                || name.Contains(
                    searchText,
                    StringComparison.OrdinalIgnoreCase)
                    ? Visibility.Visible
                    : Visibility.Collapsed;
        }
    }

    private void Destiny2_Click(
        object sender,
        RoutedEventArgs e)
    {
        (Window.GetWindow(this) as MainWindow)
            ?.NavigateToDestiny2();
    }

    private void Minecraft_Click(
        object sender,
        RoutedEventArgs e)
    {
        (Window.GetWindow(this) as MainWindow)
            ?.NavigateToMinecraft();
    }

    private void CallofDuty_Click(
        object sender,
        RoutedEventArgs e)
    {
        (Window.GetWindow(this) as MainWindow)
            ?.NavigateToCallofDuty();
    }

    private void Rainbow6Siege_Click(
        object sender,
        RoutedEventArgs e)
    {
        (Window.GetWindow(this) as MainWindow)
            ?.NavigateToRainbow6Siege();
    }

    private void RocketLeague_Click(
        object sender,
        RoutedEventArgs e)
    {
        (Window.GetWindow(this) as MainWindow)
            ?.NavigateToRocketLeague();
    }

    private void FiveM_Click(
        object sender,
        RoutedEventArgs e)
    {
        (Window.GetWindow(this) as MainWindow)
            ?.NavigateToFiveM();
    }

    private void Helldivers_Click(
        object sender,
        RoutedEventArgs e)
    {
        (Window.GetWindow(this) as MainWindow)
            ?.NavigateToHelldivers();
    }

    private void MarvelRivals_Click(
        object sender,
        RoutedEventArgs e)
    {
        (Window.GetWindow(this) as MainWindow)
            ?.NavigateToMarvelRivals();
    }
}