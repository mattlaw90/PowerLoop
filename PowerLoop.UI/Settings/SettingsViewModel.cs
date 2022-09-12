// <copyright file="SettingsViewModel.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.UI.Settings
{
    using System.Collections.Generic;
    using CommunityToolkit.Mvvm.ComponentModel;

    public class SettingsViewModel : ObservableObject
    {
        public SettingsViewModel()
        {
            this.LoopItems.Add(new LoopItem()
            {
                Order = 1,
                Type = LoopItemType.Image,
                Path = "images/ClubCrest.png",
            });

            this.LoopItems.Add(new LoopItem()
            {
                Order = 2,
                Type = LoopItemType.Web,
                Path = "https://www.englandrugby.com/fixtures-and-results/search-results?team=14247&season=2022-2023#results",
            });

            this.LoopItems.Add(new LoopItem()
            {
                Order = 3,
                Type = LoopItemType.Web,
                Path = "https://www.englandrugby.com/fixtures-and-results/search-results?team=14247&season=2022-2023#table",
            });

            this.LoopItems.Add(new LoopItem()
            {
                Order = 4,
                Type = LoopItemType.Web,
                Path = "https://www.englandrugby.com/fixtures-and-results/search-results?team=14247&season=2022-2023#fixtures",
            });
        }

        public List<LoopItem> LoopItems { get; } = new List<LoopItem>();

        public void GetSettings()
        {

        }

        public void SetSettings()
        {

        }
    }
}
