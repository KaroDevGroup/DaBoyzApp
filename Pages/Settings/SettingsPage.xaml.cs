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


    // ================================================================
    // LOAD SETTINGS
    // ================================================================

    private void LoadSettings()
    {
        // ------------------------------------------------------------
        // UI ANIMATIONS
        // ------------------------------------------------------------

        UiAnimationsCheckBox.IsChecked =
            SettingsManager.UiAnimationsEnabled;


        // ------------------------------------------------------------
        // FPS
        // ------------------------------------------------------------

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


    // ================================================================
    // FPS SETTING
    // ================================================================

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


        // Apply immediately to MainWindow

        if (Application.Current.MainWindow is MainWindow mainWindow)
        {
            mainWindow.SetParticleFPS(fps);
        }
    }


    // ================================================================
    // UI ANIMATIONS
    // ================================================================

    private void UiAnimationsCheckBox_Changed(
        object sender,
        RoutedEventArgs e)
    {
        bool animationsEnabled =
            UiAnimationsCheckBox.IsChecked == true;


        SettingsManager.UiAnimationsEnabled =
            animationsEnabled;


        // Apply immediately to MainWindow

        if (Application.Current.MainWindow is MainWindow mainWindow)
        {
            mainWindow.SetUIAnimationsEnabled(
                animationsEnabled);
        }
    }


    // ================================================================
    // SAVE SETTINGS
    // ================================================================

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