using System.Configuration;
using System.Data;
using System.Windows;

namespace DaBoyzApp;

public partial class App : Application
{
    protected override void OnStartup(
        StartupEventArgs e)
    {
        base.OnStartup(e);

        SplashWindow splash =
            new SplashWindow();

        splash.Show();
    }
}