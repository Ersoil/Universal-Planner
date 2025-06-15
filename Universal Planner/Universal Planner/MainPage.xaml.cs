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
using Windows.ApplicationModel.Core;
using Universal_Planner.Pages;
using Universal_Planner.Componets.viewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Universal_Planner
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            Window.Current.SetTitleBar(AppTitleBar);
            MainFrame.Navigate(typeof(StartScreen));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationMenu.IsPaneOpen = !NavigationMenu.IsPaneOpen;
        }
        private void PageIndex_Tapped(object sender, TappedRoutedEventArgs e)
        {
            switch (PageIndex.SelectedIndex)
            {
                case 0:
                    MainFrame.Navigate(typeof(StartScreen));
                    break;
                case 1:
                    MainFrame.Navigate(typeof(planner));
                    break;
                default:
                    MainFrame.Navigate(typeof(StartScreen));
                    break;
            }
            NavigationMenu.IsPaneOpen = false;
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(SettingsPage));
            NavigationMenu.IsPaneOpen = false;
        }
    }
}
