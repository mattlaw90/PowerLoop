// <copyright file="ILoopItem.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings
{
    using System.Collections.Generic;

    public interface ILoopItem
    {
        string FileName { get; set; }

        bool IsMedia { get; }

        int Length { get; set; }

        int Order { get; set; }

        string Path { get; set; }

        LoopItemType Type { get; set; }


        void CopyFrom(LoopItem? loopItem);

        ValidationResult IsValid(List<LoopItem> existingItems);
    }
}