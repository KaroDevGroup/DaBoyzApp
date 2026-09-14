// KaroDevGroup
// Josh Karo

using System.Windows;

namespace DaBoyzApp;

public partial class App : Application
{
    protected override void OnStartup(
        StartupEventArgs e)
    {
        base.OnStartup(e);

        ShutdownMode =
            ShutdownMode.OnExplicitShutdown;

        RunStartupSequence();
    }

    private void RunStartupSequence()
    {

        var antiCheatWindow =
            new AntiCheatWindow();

        bool? antiCheatResult =
            antiCheatWindow.ShowDialog();

        if (antiCheatResult != true)
        {
            Shutdown();
            return;
        }

        var splash =
            new SplashWindow();

        splash.Show();
    }
}