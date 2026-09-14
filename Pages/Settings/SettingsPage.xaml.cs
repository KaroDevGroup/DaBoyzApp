// KaroDevGroup
// Josh Karo

using System.Windows;
using System.Windows.Controls;
using DaBoyzApp;

namespace DaBoyzApp.Pages;

public partial class SettingsPage : Page
{
    public SettingsPage()
    {
        InitializeComponent();

        LoadSettings();
    }

    private void LoadSettings()
    {

        UiAnimationsCheckBox.IsChecked =
            SettingsManager.UiAnimationsEnabled;

        LaunchMaximizedCheckBox.IsChecked =
            SettingsManager.LaunchMaximized;

        switch (SettingsManager.AnimationFPS)
        {
            case 30:
                FpsComboBox.SelectedIndex = 0;
                break;

            case 60:
                FpsComboBox.SelectedIndex = 1;
                break;

            case 120:
                FpsComboBox.SelectedIndex = 2;
                break;

            case 144:
                FpsComboBox.SelectedIndex = 3;
                break;

            default:
                FpsComboBox.SelectedIndex = 1;
                break;
        }
    }

    private void FpsComboBox_SelectionChanged(
        object sender,
        SelectionChangedEventArgs e)
    {
        if (FpsComboBox.SelectedItem is not ComboBoxItem selectedItem)
            return;

        string? selectedFps =
            selectedItem.Content?.ToString();

        if (selectedFps == null)
            return;

        int fps = 60;

        switch (selectedFps)
        {
            case "30 FPS":
                fps = 30;
                break;

            case "60 FPS":
                fps = 60;
                break;

            case "120 FPS":
                fps = 120;
                break;

            case "144 FPS":
                fps = 144;
                break;
        }

        SettingsManager.AnimationFPS = fps;

        if (Application.Current.MainWindow is MainWindow mainWindow)
        {
            mainWindow.SetParticleFPS(fps);
        }
    }

    private void UiAnimationsCheckBox_Changed(
        object sender,
        RoutedEventArgs e)
    {
        bool animationsEnabled =
            UiAnimationsCheckBox.IsChecked == true;

        SettingsManager.UiAnimationsEnabled =
            animationsEnabled;

        if (Application.Current.MainWindow is MainWindow mainWindow)
        {
            mainWindow.SetUIAnimationsEnabled(
                animationsEnabled);
        }
    }

    private void LaunchMaximizedCheckBox_Changed(
        object sender, 
        RoutedEventArgs e)
    {
        SettingsManager.LaunchMaximized =
            LaunchMaximizedCheckBox.IsChecked == true;
    }

    private void SaveSettingsButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        SettingsManager.Save();

        MessageBox.Show(
            "Settings saved successfully.",
            "Da Boyz Settings",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
    }
}