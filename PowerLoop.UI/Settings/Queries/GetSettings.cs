// <copyright file="GetSettings.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.UI.Settings.Queries
{
    using System.Collections.Generic;

    public class GetSettings
    {
        public AppSettings Execute()
        {
            // TODO Return list items parsed from file
            var appSettings = new AppSettings
            {
                DefaultInterval = 5,
                LoopItems = new List<LoopItem>(),
            };

            appSettings.LoopItems.Add(new LoopItem()
            {
                Order = 1,
                Type = LoopItemType.Image,
                Path = "images/ClubCrest.png",
            });

            appSettings.LoopItems.Add(new LoopItem()
            {
                Order = 2,
                Type = LoopItemType.Web,
                Path = "https://www.englandrugby.com/fixtures-and-results/search-results?team=14247&season=2022-2023#results",
            });

            appSettings.LoopItems.Add(new LoopItem()
            {
                Order = 3,
                Type = LoopItemType.Web,
                Path = "https://www.englandrugby.com/fixtures-and-results/search-results?team=14247&season=2022-2023#table",
            });

            appSettings.LoopItems.Add(new LoopItem()
            {
                Order = 4,
                Type = LoopItemType.Web,
                Path = "https://www.englandrugby.com/fixtures-and-results/search-results?team=14247&season=2022-2023#fixtures",
            });

            appSettings.LoopItems.Add(new LoopItem()
            {
                Order = 5,
                Type = LoopItemType.Video,
                Path = "images/Test-slide-1.mp4",
                Length = 17,
            });

            return appSettings;
        }
    }
}
