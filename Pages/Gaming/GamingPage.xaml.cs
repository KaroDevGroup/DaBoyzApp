using System.Windows;
using System.Windows.Controls;

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
            (RocketLeagueButton, "rocket league"),
            (HelldiversButton, "helldivers 2"),
            (MarvelRivalsButton, "marvel rivals"),
            (Rainbow6SiegeButton, "rainbow six siege"),
            (FiveMButton, "fivem")
        ];

        UpdateGameFilter();
    }

    private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        UpdateGameFilter();
    }

    private void UpdateGameFilter()
    {
        string searchText = SearchBox.Text.Trim();
        SearchPlaceholder.Visibility = string.IsNullOrEmpty(searchText)
            ? Visibility.Visible
            : Visibility.Collapsed;

        foreach ((Button button, string name) in gameButtons)
        {
            button.Visibility = string.IsNullOrEmpty(searchText)
                || name.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }
    }

    private void Destiny2_Click(object sender, RoutedEventArgs e)
    {
        (Window.GetWindow(this) as MainWindow)?.NavigateToDestiny2();
    }

    private void Minecraft_Click(object sender, RoutedEventArgs e)
    {
        (Window.GetWindow(this) as MainWindow)?.NavigateToMinecraft();
    }

    private void CallofDuty_Click(object sender, RoutedEventArgs e)
    {
        (Window.GetWindow(this) as MainWindow)?.NavigateToCallofDuty();
    }

    private void Rainbow6Siege_Click(object sender, RoutedEventArgs e)
    {
        (Window.GetWindow(this) as MainWindow)?.NavigateToRainbow6Siege();
    }

    private void RocketLeague_Click(object sender, RoutedEventArgs e)
    {
        (Window.GetWindow(this) as MainWindow)?.NavigateToRocketLeague();
    }

    private void FiveM_Click(object sender, RoutedEventArgs e)
    {
        (Window.GetWindow(this) as MainWindow)?.NavigateToFiveM();
    }

    private void Helldivers_Click(object sender, RoutedEventArgs e)
    {
        (Window.GetWindow(this) as MainWindow)?.NavigateToHelldivers();
    }

    private void MarvelRivals_Click(object sender, RoutedEventArgs e)
    {
        (Window.GetWindow(this) as MainWindow)?.NavigateToMarvelRivals();
    }
}