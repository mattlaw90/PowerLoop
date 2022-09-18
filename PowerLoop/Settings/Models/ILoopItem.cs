// <copyright file="ILoopItem.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using PowerLoop.Shared;

    [JsonConverter(typeof(ConcreteConverter<LoopItem, ILoopItem>))]
    public interface ILoopItem
    {
        string FileName { get; set; }

        bool IsMedia { get; }

        int Length { get; set; }

        int Order { get; set; }

        string Path { get; set; }

        LoopItemType Type { get; set; }

        void CopyFrom(ILoopItem? loopItem);

        ValidationResult IsValid(List<ILoopItem> existingItems);
    }
}