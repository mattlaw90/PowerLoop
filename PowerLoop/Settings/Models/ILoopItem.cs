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

        /// <summary>
        /// Returns a value indicating whether the item can be moved up in the list.
        /// </summary>
        /// <param name="existingItems">The list of existing items.</param>
        /// <returns>True if it can move up.</returns>
        bool CanMoveUp(IEnumerable<ILoopItem> existingItems);

        /// <summary>
        /// Returns a value indicating whether the item can be moved down the list.
        /// </summary>
        /// <param name="existingItems">The list of existing items.</param>
        /// <returns>True if it can move down.</returns>
        bool CanMoveDown(IEnumerable<ILoopItem> existingItems);

        /// <summary>
        /// Increases the order of this item and decreases the order of the item with the order matching the incremented value.
        /// </summary>
        /// <param name="existingItems">The list of items.</param>
        void Increment(IEnumerable<ILoopItem> existingItems);

        /// <summary>
        /// Decreases the order of this item and increases the order of the item with the order matching the incremented value.
        /// </summary>
        /// <param name="existingItems">The list of items.</param>
        void Decrement(IEnumerable<ILoopItem> existingItems);

        /// <summary>
        /// Increments the order of all items at or greater than this item.
        /// </summary>
        /// <param name="existingItems">The list of items.</param>
        /// <param name="isDeleted">A value indicating whether the item is to be deleted.</param>
        void ReOrder(IEnumerable<ILoopItem> existingItems, bool isDeleted = false);
    }
}