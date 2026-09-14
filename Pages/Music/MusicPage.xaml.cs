// KaroDevGroup
// Josh Karo

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace DaBoyzApp.Pages;

public partial class MusicPage : Page
{
    private readonly ObservableCollection<BeatItem> _beats = new();

    private readonly MediaPlayer _mediaPlayer = new();

    private readonly DispatcherTimer _progressTimer;

    private BeatItem? _currentBeat;

    private bool _isPlaying;

    public MusicPage()
    {
        InitializeComponent();

        _mediaPlayer.Volume = 0.70;

        BeatList.ItemsSource = _beats;

        _mediaPlayer.MediaOpened += MediaPlayer_MediaOpened;
        _mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
        _mediaPlayer.MediaFailed += MediaPlayer_MediaFailed;

        _progressTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(250)
        };

        _progressTimer.Tick += ProgressTimer_Tick;

        LoadBeats();

        Unloaded += MusicPage_Unloaded;
    }

    private void LoadBeats()
    {
        _beats.Clear();

        string beatsFolder = Path.Combine(
            AppContext.BaseDirectory,
            "Assets",
            "Beats");

        if (!Directory.Exists(beatsFolder))
        {
            EmptyLibraryText.Visibility = Visibility.Visible;
            return;
        }

        string[] files = Directory
            .GetFiles(beatsFolder, "*.mp3")
            .OrderBy(file => file)
            .ToArray();

        foreach (string file in files)
        {
            _beats.Add(new BeatItem
            {
                Title = Path.GetFileNameWithoutExtension(file),
                FilePath = file
            });
        }

        EmptyLibraryText.Visibility =
            _beats.Count == 0
                ? Visibility.Visible
                : Visibility.Collapsed;
    }

    private void BeatList_SelectionChanged(
        object sender,
        SelectionChangedEventArgs e)
    {
        if (BeatList.SelectedItem is BeatItem beat)
        {
            _currentBeat = beat;

            NowPlayingText.Text = beat.Title;

            PlayPauseButton.Content = "PLAY";
        }
    }

    private void BeatList_MouseDoubleClick(
        object sender,
        MouseButtonEventArgs e)
    {
        if (BeatList.SelectedItem is BeatItem beat)
        {
            PlayBeat(beat);
        }
    }

    private void PlayBeat(BeatItem beat)
    {
        try
        {
            _mediaPlayer.Stop();
            _mediaPlayer.Close();

            _currentBeat = beat;

            _mediaPlayer.Open(
                new Uri(
                    beat.FilePath,
                    UriKind.Absolute));

            _mediaPlayer.Play();

            _isPlaying = true;

            NowPlayingText.Text = beat.Title;

            PlayPauseButton.Content = "PAUSE";

            _progressTimer.Start();
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Unable to play this beat.\n\n{ex.Message}",
                "Da Boyz Music",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }

    private void VolumeSlider_ValueChanged(
        object sender,
        RoutedPropertyChangedEventArgs<double> e)
    {
        double volume = e.NewValue / 100.0;

        _mediaPlayer.Volume = volume;

        if (VolumeText != null)
        {
            VolumeText.Text = $"{Math.Round(e.NewValue)}%";
        }
    }

    private void PlayPauseButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        if (_currentBeat == null)
        {
            if (_beats.Count == 0)
                return;

            BeatList.SelectedIndex = 0;

            _currentBeat = _beats[0];

            PlayBeat(_currentBeat);

            return;
        }

        if (_isPlaying)
        {
            _mediaPlayer.Pause();

            _isPlaying = false;

            PlayPauseButton.Content = "PLAY";

            return;
        }

        if (_mediaPlayer.Source == null)
        {
            PlayBeat(_currentBeat);

            return;
        }

        _mediaPlayer.Play();

        _isPlaying = true;

        PlayPauseButton.Content = "PAUSE";

        _progressTimer.Start();
    }

    private void StopButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        _mediaPlayer.Stop();

        _isPlaying = false;

        PlayPauseButton.Content = "PLAY";

        ProgressSlider.Value = 0;

        CurrentTimeText.Text = "0:00";
    }

    private void PreviousButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        if (_beats.Count == 0)
            return;

        int index = BeatList.SelectedIndex;

        if (index <= 0)
        {
            index = _beats.Count - 1;
        }
        else
        {
            index--;
        }

        BeatList.SelectedIndex = index;

        BeatList.ScrollIntoView(
            BeatList.SelectedItem);

        PlayBeat(_beats[index]);
    }

    private void NextButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        if (_beats.Count == 0)
            return;

        int index = BeatList.SelectedIndex;

        if (index < 0 ||
            index >= _beats.Count - 1)
        {
            index = 0;
        }
        else
        {
            index++;
        }

        BeatList.SelectedIndex = index;

        BeatList.ScrollIntoView(
            BeatList.SelectedItem);

        PlayBeat(_beats[index]);
    }

    private void MediaPlayer_MediaOpened(
        object? sender,
        EventArgs e)
    {
        if (!_mediaPlayer.NaturalDuration.HasTimeSpan)
            return;

        TimeSpan duration =
            _mediaPlayer.NaturalDuration.TimeSpan;

        ProgressSlider.Maximum =
            duration.TotalSeconds;

        TotalTimeText.Text =
            FormatTime(duration);
    }

    private void MediaPlayer_MediaEnded(
        object? sender,
        EventArgs e)
    {
        Dispatcher.Invoke(() =>
        {
            NextButton_Click(
                this,
                new RoutedEventArgs());
        });
    }

    private void MediaPlayer_MediaFailed(
        object? sender,
        ExceptionEventArgs e)
    {
        Dispatcher.Invoke(() =>
        {
            _isPlaying = false;

            PlayPauseButton.Content = "PLAY";

            MessageBox.Show(
                $"The beat could not be played.\n\n{e.ErrorException?.Message}",
                "Da Boyz Music",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        });
    }

    private void ProgressTimer_Tick(
        object? sender,
        EventArgs e)
    {
        if (!_mediaPlayer.NaturalDuration.HasTimeSpan)
            return;

        TimeSpan position =
            _mediaPlayer.Position;

        ProgressSlider.Value =
            position.TotalSeconds;

        CurrentTimeText.Text =
            FormatTime(position);
    }

    private void ProgressSlider_PreviewMouseLeftButtonUp(
        object sender,
        MouseButtonEventArgs e)
    {
        if (!_mediaPlayer.NaturalDuration.HasTimeSpan)
            return;

        _mediaPlayer.Position =
            TimeSpan.FromSeconds(
                ProgressSlider.Value);
    }

    private static string FormatTime(
        TimeSpan time)
    {
        if (time.TotalHours >= 1)
        {
            return time.ToString(@"h\:mm\:ss");
        }

        return time.ToString(@"m\:ss");
    }

    private void MusicPage_Unloaded(
        object sender,
        RoutedEventArgs e)
    {
        _progressTimer.Stop();

        _mediaPlayer.Stop();

        _mediaPlayer.Close();

        _isPlaying = false;
    }
}

public sealed class BeatItem
{
    public string Title { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;
}