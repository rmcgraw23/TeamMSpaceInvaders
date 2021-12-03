﻿using System;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace SpaceInvaders.View
{
    /// <summary>
    ///     The page for the start screen.
    /// </summary>
    /// <seealso cref="Windows.UI.Xaml.Controls.Page" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector" />
    /// <seealso cref="Windows.UI.Xaml.Markup.IComponentConnector2" />
    public sealed partial class StartScreen
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StartScreen"/> class.
        /// Precondition: none
        /// Post-condition: Creates a new start screen.
        /// </summary>
        public StartScreen()
        {
            this.InitializeComponent();

        }

        #endregion

        #region Methods

        private void startGame_Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.waitOnStart();
        }

        private async void waitOnStart()
        {
            var currentAV = ApplicationView.GetForCurrentView();
            var newAV = CoreApplication.CreateNewView();
            await newAV.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                var newWindow = Window.Current;
                var newAppView = ApplicationView.GetForCurrentView();

                var frame = new Frame();
                frame.Navigate(typeof(MainPage), null);
                newWindow.Content = frame;
                newWindow.Activate();

                await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newAppView.Id, ViewSizePreference.UseMinimum,
                    currentAV.Id, ViewSizePreference.UseMinimum);
            });

        }

        private void viewHighScoreBoard_Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.waitOnScoreBoard();
        }

        private async void waitOnScoreBoard()
        {
            var currentAV = ApplicationView.GetForCurrentView();
            var newAV = CoreApplication.CreateNewView();
            await newAV.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
            {
                var newWindow = Window.Current;
                var newAppView = ApplicationView.GetForCurrentView();

                var frame = new Frame();
                frame.Navigate(typeof(HighScoreBoardView), null);
                newWindow.Content = frame;
                newWindow.Activate();

                await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newAppView.Id, ViewSizePreference.UseMinimum,
                    currentAV.Id, ViewSizePreference.UseMinimum);
            });

        }

        private void resetHighScoreBoard_Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }

        #endregion
    }
}
