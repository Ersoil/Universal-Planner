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
using System.Diagnostics;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Universal_Planner.Pages
{
    public sealed partial class SettingsPage : Page
    {
        private enum Section
        {
            General,
            Notifications,
            Synchronization,
            About
        }

        public SettingsPage()
        {
            this.InitializeComponent();

            Debug.WriteLine("SettingsPage ctor");        // ① ctor
            this.Loaded += OnPageLoaded;
        }

        private void OnPageLoaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("OnPageLoaded fired");       // ② Loaded
                                                         // Установим дефолтный выбор
            if (SettingsList.Items.Count > 0)
            {
                SettingsList.SelectedIndex = 0;
                Debug.WriteLine("SelectedIndex set to 0");
            }
            else
            {
                Debug.WriteLine("SettingsList.Items.Count is 0!");
            }
        }

        private void SettingsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("SettingsList_SelectionChanged");  // ③ SelectionChanged

            var item = SettingsList.SelectedItem as ListViewItem;
            if (item == null)
            {
                Debug.WriteLine(" SelectedItem is null");
                return;
            }

            Debug.WriteLine($" SelectedItem.Content = {item.Content}, Tag = {item.Tag}");

            if (Enum.TryParse<Section>(item.Tag?.ToString(), out var section))
            {
                Debug.WriteLine($" Parsed section = {section}");
                ShowSection(section);
            }
            else
            {
                Debug.WriteLine(" Failed to parse section from Tag");
            }
        }

        private void ShowSection(Section section)
        {
            Debug.WriteLine($"ShowSection({section})");      // ④ ShowSection start

            SettingsContent.Children.Clear();
            Debug.WriteLine(" SettingsContent.Children cleared");

            UserControl controlToShow = null;
            switch (section)
            {
                case Section.General:
                    controlToShow = new SettingsPageGeneral();
                    break;
                case Section.Notifications:
                    controlToShow = CreatePlaceholder("Уведомления");
                    break;
                case Section.Synchronization:
                    controlToShow = CreatePlaceholder("Синхронизация");
                    break;
                case Section.About:
                    controlToShow = CreatePlaceholder("О приложении");
                    break;
                default:
                    controlToShow = CreatePlaceholder("Неизвестная секция");
                    break;
            }

            if (controlToShow != null)
            {
                SettingsContent.Children.Add(controlToShow);
                Debug.WriteLine($" Added control {controlToShow.GetType().Name}");
            }
            else
            {
                Debug.WriteLine(" controlToShow is null!");
            }
        }

        private UserControl CreatePlaceholder(string text)
        {
            return new UserControl
            {
                Content = new TextBlock
                {
                    Text = $"[{text}] секция ещё не реализована.",
                    FontSize = 18,
                    Margin = new Thickness(20)
                }
            };
        }
    }
}