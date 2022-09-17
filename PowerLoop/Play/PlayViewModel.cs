// <copyright file="PlayViewModel.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Play
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Windows.Input;
    using System.Windows.Threading;
    using CommunityToolkit.Mvvm.ComponentModel;
    using MudBlazor;
    using PowerLoop.Settings;
    using PowerLoop.Settings.Queries;
    using PowerLoop.Shared;

    public class PlayViewModel : ObservableObject, INotifier
    {
        private readonly GetSettings getSettings;
        private DispatcherTimer timer;
        private int minOrder;
        private int maxOrder;
        private LoopItem currentItem;
        private bool isPlaying;
        private AppSettings appSettings;

        /// <inheritdoc/>
        public event Action<string, Severity> Notified;

        public event Action<LoopItem> Cycling;

        public PlayViewModel(GetSettings getSettings)
        {
            this.getSettings = getSettings;
        }

        /// <summary>
        /// Gets or sets the current item being displayed.
        /// </summary>
        public LoopItem CurrentItem { get => this.currentItem; set => this.SetProperty(ref this.currentItem, value); }

        /// <summary>
        /// Gets or sets the collection of items.
        /// </summary>
        public List<LoopItem> Items { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the timer is playing.
        /// </summary>
        public bool IsPlaying { get => this.isPlaying; set => this.SetProperty(ref this.isPlaying, value); }

        /// <summary>
        /// Get the settings, set the first item and start the timer.
        /// </summary>
        public void Start()
        {
            this.GetSettings();

            // If the timer is not already playing, start it
            if (this.timer != null && !this.timer.IsEnabled)
            {
                // Cycle once to set the first item
                this.Cycle(this, new EventArgs());

                // Start
                this.IsPlaying = true;
                this.timer.Start();
            }
        }

        /// <summary>
        /// Stop the timer.
        /// </summary>
        public void Stop()
        {
            // Stop the timer
            this.IsPlaying = false;
            this.timer.Stop();
        }

        public bool OnTryStop(KeyEventArgs? args)
        {
            if (args != null)
            {
                if (args.Key == Key.Escape)
                {
                    this.Stop();
                    return true;
                }
                else
                {
                    // Notify wrong key
                    this.Notified?.Invoke($"Press Escape to exit loop.", Severity.Info);
                }
            }

            return false;
        }

        private void Cycle(object? sender, System.EventArgs e)
        {
            // TODO Display transition state
            var nextItem = this.CurrentItem?.Order == this.maxOrder || this.CurrentItem == null
                ? this.Items.First(i => i.Order == this.minOrder)
                : this.Items.First(i => i.Order > this.currentItem.Order);

            // Change the interval depending on length of item
            // Item length is calculated on settings config
            this.timer.Interval = new System.TimeSpan(0, 0, Math.Max(this.appSettings.DefaultInterval, nextItem.Length));

            if (nextItem.IsMedia)
            {
                this.Cycling?.Invoke(nextItem);
            }

            this.CurrentItem = nextItem;
        }

        private void GetSettings()
        {
            // Get items and order them
            if (this.getSettings.Execute() is AppSettings settings)
            {
                this.appSettings = settings;

                if (this.timer == null)
                {
                    // Initialise the timer
                    this.timer = new DispatcherTimer();
                    this.timer.Tick += this.Cycle;
                    this.timer.Interval = new System.TimeSpan(0, 0, this.appSettings.DefaultInterval);
                }

                this.Items = this.appSettings.LoopItems.OrderBy(i => i.Order).ToList();

                // Calc the min and max order for looping
                var orders = this.Items.Select(item => item.Order);
                this.maxOrder = orders.Max();
                this.minOrder = orders.Min();
            }
        }
    }
}
