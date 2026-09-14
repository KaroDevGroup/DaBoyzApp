// KaroDevGroup
// Josh Karo

using System;
using System.IO;
using System.Text.Json;

namespace DaBoyzApp;

public static class SettingsManager
{
    private static readonly string SettingsFolder =
        Path.Combine(
            Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
            "DaBoyzApp");

    private static readonly string SettingsFile =
        Path.Combine(
            SettingsFolder,
            "settings.json");

    public static bool UiAnimationsEnabled { get; set; } = true;

    public static string ApplicationTheme { get; set; } =
        "Da Boyz Dark";
    
    public static bool LaunchMaximized { get; set; } = true;

    public static int AnimationFPS { get; set; } = 60;

    public static void Load()
    {
        try
        {
            if (!File.Exists(SettingsFile))
            {
                return;
            }

            string json =
                File.ReadAllText(SettingsFile);

            AppSettings? settings =
                JsonSerializer.Deserialize<AppSettings>(
                    json);

            if (settings == null)
            {
                return;
            }

            UiAnimationsEnabled =
                settings.UiAnimationsEnabled;

            AnimationFPS =
                settings.AnimationFPS;

            ApplicationTheme =
                settings.ApplicationTheme
                ?? "Da Boyz Dark";

            LaunchMaximized =
                settings.LaunchMaximized;
        }
        catch
        {
            // If settings cannot be loaded,
            // use the default values.
        }
    }

    public static void Save()
    {
        try
        {
            Directory.CreateDirectory(
                SettingsFolder);

            AppSettings settings =
                new AppSettings
                {
                    UiAnimationsEnabled =
                        UiAnimationsEnabled,

                    AnimationFPS =
                        AnimationFPS,

                    ApplicationTheme =
                        ApplicationTheme,

                    LaunchMaximized =
                        LaunchMaximized
                };

            string json =
                JsonSerializer.Serialize(
                    settings,
                    new JsonSerializerOptions
                    {
                        WriteIndented = true
                    });

            File.WriteAllText(
                SettingsFile,
                json);
        }
        catch
        {
            // Settings failure should never
            // crash the application.
        }
    }

    private sealed class AppSettings
    {
        public bool UiAnimationsEnabled { get; set; } = true;

        public int AnimationFPS { get; set; } = 60;

        public string ApplicationTheme { get; set; } =
            "Da Boyz Dark";

        public bool LaunchMaximized { get; set; } = true;
    }
}