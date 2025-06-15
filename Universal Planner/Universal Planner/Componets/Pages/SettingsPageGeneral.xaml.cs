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

namespace Universal_Planner.Pages
{
    public sealed partial class SettingsPageGeneral : UserControl
    {
        public SettingsPageGeneral()
        {
            this.InitializeComponent();
        }

        private void OnExampleToggleToggled(object sender, RoutedEventArgs e)
        {
            bool isOn = ExampleToggle.IsOn;
            // TODO: сохранение состояния переключателя
        }

        // Другой переключатель
        private void ExampleToggle_Toggled(object sender, RoutedEventArgs e)
        {
            // Обработка события переключения
            var toggleSwitch = sender as ToggleSwitch;
            if (toggleSwitch != null)
            {
                // Логика для обработки изменения состояния переключателя
                if (toggleSwitch.IsOn)
                {
                    // Действие при включении
                }
                else
                {
                    // Действие при выключении
                }
            }
        }
    }
}
