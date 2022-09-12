﻿// <copyright file="PlayViewModel.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.UI.Play
{
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Linq;
    using System.Windows.Threading;
    using CommunityToolkit.Mvvm.ComponentModel;
    using PowerLoop.UI.Settings;

    public class PlayViewModel : ObservableObject
    {
        private readonly DispatcherTimer timer;
        private LoopItem currentItem;
        private int minOrder;
        private int maxOrder;
        private bool showItem;
        private string currentUri = "about:blank";
        private bool isPlaying;

        public PlayViewModel()
        {
            this.timer = new DispatcherTimer();
            this.timer.Tick += this.Cycle;
            this.timer.Interval = new System.TimeSpan(0, 0, 5);

            this.Items.Add(new LoopItem()
            {
                Order = 1,
                Type = LoopItemType.Image,
                Path = "images/ClubCrest.png",
            });

            this.Items.Add(new LoopItem()
            {
                Order = 2,
                Type = LoopItemType.Web,
                Path = "https://www.englandrugby.com/fixtures-and-results/search-results?team=14247&season=2022-2023#results",
            });

            this.Items.Add(new LoopItem()
            {
                Order = 3,
                Type = LoopItemType.Web,
                Path = "https://www.englandrugby.com/fixtures-and-results/search-results?team=14247&season=2022-2023#table",
            });

            this.Items.Add(new LoopItem()
            {
                Order = 4,
                Type = LoopItemType.Web,
                Path = "https://www.englandrugby.com/fixtures-and-results/search-results?team=14247&season=2022-2023#fixtures",
            });

            var orders = this.Items.Select(item => item.Order);
            this.maxOrder = orders.Max();
            this.minOrder = orders.Min();
        }

        public LoopItem CurrentItem { get => this.currentItem; set => this.SetProperty(ref this.currentItem, value); }

        public ObservableCollection<LoopItem> Items { get; } = new ObservableCollection<LoopItem>();

        public bool ShowItem { get => this.showItem; set => this.SetProperty(ref this.showItem, value); }

        public string CurrentUri { get => this.currentUri; set => this.SetProperty(ref this.currentUri, value); }

        public bool IsPlaying { get => this.isPlaying; set => this.SetProperty(ref this.isPlaying, value); }

        public void Start()
        {
            if (!this.timer.IsEnabled)
            {
                // Set first item
                this.CurrentItem = this.Items[0];
                this.ShowItem = true;

                this.IsPlaying = true;
                this.timer.Start();
            }
        }

        public void Stop()
        {
            this.IsPlaying = false;
            this.timer.Stop();
        }

        private void Cycle(object? sender, System.EventArgs e)
        {
            // TODO Dispaly transition state
            var nextItem = this.CurrentItem?.Order == this.maxOrder || this.CurrentItem == null
                ? this.Items.First(i => i.Order == this.minOrder)
                : this.Items.First(i => i.Order == this.currentItem.Order + 1);

            if (nextItem.Type == LoopItemType.Web)
            {
                this.CurrentUri = nextItem.Path;
                this.ShowItem = false;
            }
            else
            {
                this.ShowItem = true;
            }

            this.CurrentItem = nextItem;
        }
    }
}
