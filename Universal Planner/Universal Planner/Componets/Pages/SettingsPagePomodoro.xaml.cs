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
using Windows.Storage;

namespace Universal_Planner.Componets.Pages
{
    public sealed partial class SettingsPagePomodoro : UserControl
    {
        private readonly ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

        public SettingsPagePomodoro()
        {
            this.InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            FocusBox.Text = (localSettings.Values["PomodoroFocusMinutes"] ?? "25").ToString();
            ShortBreakBox.Text = (localSettings.Values["PomodoroShortBreak"] ?? "5").ToString();
            LongBreakBox.Text = (localSettings.Values["PomodoroLongBreak"] ?? "15").ToString();
            RoundsBox.Text = (localSettings.Values["PomodoroRounds"] ?? "4").ToString();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(FocusBox.Text, out int focus))
                localSettings.Values["PomodoroFocusMinutes"] = focus;

            if (int.TryParse(ShortBreakBox.Text, out int shortBreak))
                localSettings.Values["PomodoroShortBreak"] = shortBreak;

            if (int.TryParse(LongBreakBox.Text, out int longBreak))
                localSettings.Values["PomodoroLongBreak"] = longBreak;

            if (int.TryParse(RoundsBox.Text, out int rounds))
                localSettings.Values["PomodoroRounds"] = rounds;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            localSettings.Values["PomodoroFocusMinutes"] = 25;
            localSettings.Values["PomodoroShortBreak"] = 5;
            localSettings.Values["PomodoroLongBreak"] = 15;
            localSettings.Values["PomodoroRounds"] = 4;
            LoadSettings();
        }
    }
}
