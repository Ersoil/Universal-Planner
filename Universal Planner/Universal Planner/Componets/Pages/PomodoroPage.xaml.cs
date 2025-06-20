using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Universal_Planner.Componets.viewModels;
using Universal_Planner.Componets.Models;
using Windows.UI.Popups;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml.Media.Animation;
using Windows.Media.Playback;
using Windows.Media.Core;
using System.Diagnostics;

namespace Universal_Planner.Pages
{
    public sealed partial class PomodoroPage : Page
    {
        private MediaPlayer whiteNoisePlayer;
        private MediaPlayer pinkNoisePlayer;

        private DispatcherTimer timer;
        private TimeSpan remainingTime;
        private TimeSpan fullTime;

        private int currentPhase = 0; // 0: Focus, 1: Short, 2: Long
        private int currentRound = 1;
        private int totalRounds = 4;
        private int sessionCount = 0;

        private readonly string[] phaseNames = { "FOCUS", "SHORT BREAK", "LONG BREAK" };

        // Duration Settings (тут можно будет заменить на настройки пользователя)
        private TimeSpan focusDuration = TimeSpan.FromMinutes(25);
        private TimeSpan shortBreakDuration = TimeSpan.FromSeconds(10);
        private TimeSpan longBreakDuration = TimeSpan.FromMinutes(15);

        private void LoadPomodoroSettings()
        {
            var settings = Windows.Storage.ApplicationData.Current.LocalSettings.Values;

            focusDuration = TimeSpan.FromMinutes(Convert.ToInt32(settings["PomodoroFocusMinutes"] ?? 25));
            shortBreakDuration = TimeSpan.FromMinutes(Convert.ToInt32(settings["PomodoroShortBreak"] ?? 5));
            longBreakDuration = TimeSpan.FromMinutes(Convert.ToInt32(settings["PomodoroLongBreak"] ?? 15));
            totalRounds = Convert.ToInt32(settings["PomodoroRounds"] ?? 4);
        }

        public PomodoroPage()
        {
            InitializeComponent();
            this.DataContext = this;
            InitTimer();
            InitNoisePlayers();
        }

        #region BINDABLE PROPERTIES

        public string TimeDisplay => remainingTime.ToString(@"mm\:ss");
        public string CurrentPhaseLabel => phaseNames[currentPhase];
        public string PhaseCounterDisplay => $"{currentRound}/{totalRounds} [{sessionCount}]";

        #endregion

        private void InitTimer()
        {
            LoadPomodoroSettings();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            SetPhase(0); // FOCUS
        }

        private void Timer_Tick(object sender, object e)
        {
            remainingTime -= TimeSpan.FromSeconds(1);

            if (remainingTime <= TimeSpan.Zero)
            {
                timer.Stop();
                NextPhase();
            }

            UpdateUI();
        }

        private void SetPhase(int phase)
        {
            currentPhase = phase;
            switch (phase)
            {
                case 0:
                    fullTime = focusDuration;
                    break;
                case 1:
                    fullTime = shortBreakDuration;
                    break;
                case 2:
                    fullTime = longBreakDuration;
                    break;
            }

            remainingTime = fullTime;
            UpdateUI();
            StartArcAnimation();
        }

        private void NextPhase()
        {
            if (currentPhase == 0)
            {
                sessionCount++;
                if (currentRound % totalRounds == 0)
                {
                    SetPhase(2); // Long
                }
                else
                {
                    SetPhase(1); // Short
                }
            }
            else
            {
                currentRound++;
                SetPhase(0); // Focus
            }

            timer.Start();
        }

        private void UpdateUI()
        {
            this.Bindings.Update(); // Обновляем биндинги
            UpdateArc(); // Синхронно обновляем прогресс
        }

        private void StartArcAnimation()
        {
            UpdateArc();
        }

        private void UpdateArc()
        {
            double stroke = ProgressPath.StrokeThickness;
            double radius = (300 - stroke) / 2;
            double center = 150;

            double angle = 360.0 * (1.0 - remainingTime.TotalSeconds / fullTime.TotalSeconds);
            double radians = (Math.PI / 180) * angle;

            double x = center + radius * Math.Sin(radians);
            double y = center - radius * Math.Cos(radians);

            ProgressFigure.StartPoint = new Point(center, stroke / 2);
            ProgressArc.Point = new Point(x, y);
            ProgressArc.Size = new Size(radius, radius);
            ProgressArc.IsLargeArc = angle > 180;
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
                PauseSymbol.Symbol = Symbol.Play;
            }
            else
            {
                timer.Start();
                PauseSymbol.Symbol = Symbol.Pause;
            }
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            NextPhase();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            SetPhase(0);
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SettingsPage), "Pomodoro");
        }

        private void InitNoisePlayers()
        {
            whiteNoisePlayer = new MediaPlayer
            {
                Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Componets/Resources/Sounds/underwater-white-noise-46423.mp3")),
                IsLoopingEnabled = true,
                Volume = 0
            };

            WhitePlayerElement.SetMediaPlayer(whiteNoisePlayer); 
            whiteNoisePlayer.Play();

            pinkNoisePlayer = new MediaPlayer
            {
                Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Componets/Resources/Sounds/pink-noise-235.mp3")),
                IsLoopingEnabled = true,
                Volume = 0
            };
            PinkPlayerElement.SetMediaPlayer(pinkNoisePlayer); // Привязка
            pinkNoisePlayer.Play();
        }


        private void WhiteNoiseSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (whiteNoisePlayer != null)
                whiteNoisePlayer.Volume = e.NewValue / 100.0;
        }

        private void PinkNoiseSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if (pinkNoisePlayer != null)
                pinkNoisePlayer.Volume = e.NewValue / 100.0;
        }

    }
}
