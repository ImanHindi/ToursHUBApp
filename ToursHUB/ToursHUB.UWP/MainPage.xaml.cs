using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace ToursHUB.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new ToursHUB.App());
            NativeCustomize();

        }

        private void NativeCustomize()
        {
            // PC Customization
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.ApplicationView"))
            {
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                if (titleBar != null)
                {
                    titleBar.BackgroundColor = (Color)App.Current.Resources["NativeAccentColor"];
                    titleBar.ButtonBackgroundColor = (Color)App.Current.Resources["NativeAccentColor"];
                }
            }

            // Mobile Customization
            //if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            //{
            //    var statusBar = StatusBar.GetForCurrentView();
            //    if (statusBar != null)
            //    {
            //        statusBar.BackgroundOpacity = 1;
            //        statusBar.BackgroundColor = (Color)App.Current.Resources["NativeAccentColor"];
            //    }
            //}

            // Launch in Window Mode
            var currentView = ApplicationView.GetForCurrentView();
            if (currentView.IsFullScreenMode)
            {
                currentView.ExitFullScreenMode();
            }
        }
    }
}
