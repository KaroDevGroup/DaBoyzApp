namespace DaBoyzApp;

public static class SettingsManager
{
    // ================================================================
    // APPEARANCE
    // ================================================================

    public static bool UiAnimationsEnabled { get; set; } = true;


    // ================================================================
    // PERFORMANCE
    // ================================================================

    public static int AnimationFPS { get; set; } = 60;


    // ================================================================
    // APPLICATION
    // ================================================================

    public static string ApplicationTheme { get; set; } = "Da Boyz Dark";


    // ================================================================
    // SAVE SETTINGS
    // ================================================================

    public static void Save()
    {
        // Settings persistence will be added here.
        // For now, values remain available while the application
        // is running.
    }
}