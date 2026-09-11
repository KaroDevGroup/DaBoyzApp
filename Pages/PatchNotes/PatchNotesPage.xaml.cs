using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using DaBoyzApp.Services;

namespace DaBoyzApp.Pages;

public partial class PatchNotesPage : Page
{
    public PatchNotesPage()
    {
        InitializeComponent();

        Loaded += PatchNotesPage_Loaded;
    }

    private void PatchNotesPage_Loaded(
        object sender,
        RoutedEventArgs e)
    {
        CardAnimationService.Stagger(
            new[]
            {
                LatestVersionCard,
                NewFeaturesCard,
                ImprovementsCard,
                FixesCard
            });
    }
}