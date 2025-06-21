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
using Windows.UI.Popups;
using Universal_Planner.Componets.viewModels;
using Universal_Planner.Componets.Models;

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
            new MessageDialog(Convert.ToString(GlobalData.Instance.TaskViewList.Count)).ShowAsync();
        }
    }
}
