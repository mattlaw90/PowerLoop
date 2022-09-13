// <copyright file="LoopItem.cs" company="Matthew Law">
// Copyright (c) Matthew Law. All rights reserved.
// </copyright>

namespace PowerLoop.UI.Settings
{
    public class LoopItem
    {
        public LoopItemType Type { get; set; }

        public string Path { get; set; }

        public int Order { get; set; }

        public int Length { get; set; }
    }
}
