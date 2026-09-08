using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;
using DaBoyzApp.Pages;

namespace DaBoyzApp;

public partial class MainWindow : Window
{
    private readonly List<Particle> particles = new();
    private readonly Random random = new();

    private readonly DispatcherTimer particleTimer;

    private const int ParticleCount = 45;
    private const double ConnectionDistance = 135.0;


    public MainWindow()
    {
        InitializeComponent();

        // Start on Home
        NavigateToHome();

        // Start background particles
        CreateParticles();

        particleTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(33)
        };

        particleTimer.Tick += AnimateParticles;
        particleTimer.Start();
    }


    // ================================================================
    // CREATE PARTICLES
    // ================================================================

    private void CreateParticles()
    {
        for (int i = 0; i < ParticleCount; i++)
        {
            double depth = random.NextDouble();

            double size =
                1.5 +
                depth * 4.5;

            double opacity =
                0.15 +
                depth * 0.65;

            bool isWhite =
                random.NextDouble() < 0.12;

            SolidColorBrush brush;

            if (isWhite)
            {
                brush = new SolidColorBrush(
                    Color.FromRgb(255, 255, 255)
                );
            }
            else
            {
                brush = new SolidColorBrush(
                    Color.FromRgb(224, 0, 0)
                );
            }

            Ellipse visual = new Ellipse
            {
                Width = size,
                Height = size,
                Fill = brush,
                Opacity = opacity
            };

            double x =
                random.NextDouble() *
                Math.Max(ParticleCanvas.ActualWidth, 900);

            double y =
                random.NextDouble() *
                Math.Max(ParticleCanvas.ActualHeight, 700);

            Canvas.SetLeft(visual, x);
            Canvas.SetTop(visual, y);

            ParticleCanvas.Children.Add(visual);

            particles.Add(new Particle
            {
                Visual = visual,

                X = x,
                Y = y,

                Depth = depth,

                SpeedX =
                    (random.NextDouble() - 0.5)
                    * (0.15 + depth * 0.45),

                SpeedY =
                    (random.NextDouble() - 0.5)
                    * (0.15 + depth * 0.45),

                BaseOpacity = opacity,

                PulseOffset =
                    random.NextDouble() *
                    Math.PI *
                    2
            });
        }
    }


    // ================================================================
    // ANIMATE PARTICLES
    // ================================================================

    private void AnimateParticles(
        object? sender,
        EventArgs e)
    {
        double width = ParticleCanvas.ActualWidth;
        double height = ParticleCanvas.ActualHeight;

        if (width <= 0 || height <= 0)
            return;

        double time =
            DateTime.Now.TimeOfDay.TotalSeconds;

        foreach (Particle particle in particles)
        {
            // Movement
            particle.X += particle.SpeedX;
            particle.Y += particle.SpeedY;


            // Wrap around edges
            if (particle.X < -10)
                particle.X = width + 10;

            if (particle.X > width + 10)
                particle.X = -10;

            if (particle.Y < -10)
                particle.Y = height + 10;

            if (particle.Y > height + 10)
                particle.Y = -10;


            // Position
            Canvas.SetLeft(
                particle.Visual,
                particle.X
            );

            Canvas.SetTop(
                particle.Visual,
                particle.Y
            );


            // Gentle pulsing
            double pulse =
                Math.Sin(
                    time * 0.7 +
                    particle.PulseOffset
                );

            particle.Visual.Opacity =
                Math.Max(
                    0.05,
                    particle.BaseOpacity +
                    pulse * 0.10
                );
        }

        UpdateConnections();
    }


    // ================================================================
    // UPDATE PARTICLE CONNECTIONS
    // ================================================================

    private void UpdateConnections()
    {
        ConnectionCanvas.Children.Clear();

        for (int i = 0; i < particles.Count; i++)
        {
            Particle first = particles[i];

            for (int j = i + 1; j < particles.Count; j++)
            {
                Particle second = particles[j];

                double dx =
                    first.X -
                    second.X;

                double dy =
                    first.Y -
                    second.Y;

                double distance =
                    Math.Sqrt(
                        dx * dx +
                        dy * dy
                    );

                if (distance > ConnectionDistance)
                    continue;

                double strength =
                    1.0 -
                    (distance / ConnectionDistance);

                byte alpha =
                    (byte)(
                        255 *
                        strength *
                        0.22
                    );

                Line connection = new Line
                {
                    X1 = first.X,
                    Y1 = first.Y,

                    X2 = second.X,
                    Y2 = second.Y,

                    Stroke =
                        new SolidColorBrush(
                            Color.FromArgb(
                                alpha,
                                224,
                                0,
                                0
                            )
                        ),

                    StrokeThickness =
                        0.6 +
                        strength * 0.7
                };

                ConnectionCanvas.Children.Add(
                    connection
                );
            }
        }
    }


    // ================================================================
    // NAVIGATION
    // ================================================================

    private void HomeButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        NavigateToHome();
    }


    private void GamingButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        NavigateToGaming();
    }


    private void MusicButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        NavigateToMusic();
    }


    private void PatchNotesButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        NavigateToPatchNotes();
    }


    private void AdminButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        NavigateToAdmin();
    }

    private void SettingsButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        NavigateToSettings();
    }

    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    // ================================================================
    // NAVIGATION METHODS
    // ================================================================

    public void NavigateToHome()
    {
        MainFrame.Navigate(new HomePage());
        SetSelectedButton(HomeButton);
    }


    public void NavigateToGaming()
    {
        MainFrame.Navigate(new GamingPage());
        SetSelectedButton(GamingButton);
    }


    public void NavigateToMusic()
    {
        MainFrame.Navigate(new MusicPage());
        SetSelectedButton(MusicButton);
    }


    public void NavigateToPatchNotes()
    {
        MainFrame.Navigate(new PatchNotesPage());
        SetSelectedButton(PatchNotesButton);
    }


    public void NavigateToAdmin()
    {
        MainFrame.Navigate(new AdminPage());
        SetSelectedButton(AdminButton);
    }

    public void NavigateToAdminDashboard()
    {
        MainFrame.Navigate(new AdminDashboardPage());
    }

    public void NavigateToSettings()
    {
        MainFrame.Navigate(new SettingsPage());
        SetSelectedButton(SettingsButton);
    }

    public void NavigateToRules()
    {
        MainFrame.Navigate(new RulesPage());
    }

    public void NavigateToDiscordCommands()
    {
        MainFrame.Navigate(new DiscordCommandsPage());
    }

    public void NavigateToStaffMembers()
    {
        MainFrame.Navigate(new StaffMembersPage());
    }

    public void NavigateToDestiny2()
    {
        MainFrame.Navigate(new Destiny2Page());
    }

    public void NavigateToMinecraft()
    {
        MainFrame.Navigate(new MinecraftPage());
    }

    public void NavigateToCallofDuty()
    {
        MainFrame.Navigate(new CallofDutyPage());
    }

    public void NavigateToRainbow6Siege()
    {
        MainFrame.Navigate(new Rainbow6SiegePage());
    }

    public void NavigateToRocketLeague()
    {
        MainFrame.Navigate(new RocketLeaguePage());
    }

    public void NavigateToFiveM()
    {
        MainFrame.Navigate(new FiveMPage());
    }

    public void NavigateToHelldivers()
    {
        MainFrame.Navigate(new HelldiversPage());
    }

    public void NavigateToMarvelRivals()
    {
        MainFrame.Navigate(new MarvelRivalsPage());
    }

    // ================================================================
    // PARTICLE FPS
    // ================================================================

    public void SetParticleFPS(int fps)
    {
        if (fps <= 0)
            return;

        particleTimer.Interval =
            TimeSpan.FromSeconds(1.0 / fps);
    }

    // ================================================================
    // UI ANIMATIONS
    // ================================================================

    public void SetUIAnimationsEnabled(
        bool enabled)
    {
        // UI animation system will use this setting.
        // We will connect page transitions and other
        // interface animations here.
    }

    // ================================================================
    // SIDEBAR SELECTION
    // ================================================================

    private void SetSelectedButton(
        Button selectedButton)
    {
        HomeButton.Tag = null;
        GamingButton.Tag = null;
        MusicButton.Tag = null;
        PatchNotesButton.Tag = null;
        AdminButton.Tag = null;
        SettingsButton.Tag = null;

        selectedButton.Tag = "Selected";
    }


    // ================================================================
    // PARTICLE DATA
    // ================================================================

    private class Particle
    {
        public required Ellipse Visual { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public double Depth { get; set; }

        public double SpeedX { get; set; }

        public double SpeedY { get; set; }

        public double BaseOpacity { get; set; }

        public double PulseOffset { get; set; }
    }
}