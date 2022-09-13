// <copyright file="LoopItem.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.UI.Settings
{
    using System.Collections.Generic;
    using System.Linq;

    public class LoopItem
    {
        /// <summary>
        /// Gets or sets the type of the loop item.
        /// </summary>
        public LoopItemType Type { get; set; }

        /// <summary>
        /// Gets or sets the path to the item - web or file path.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the order of the item - the loop order.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the length of the item - for videos which may need to extend the default loop interval.
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Returns a new <see cref="LoopItem"/>.
        /// </summary>
        /// <param name="loopItem">The optional <see cref="LoopItem"/> to initialise values from.</param>
        /// <returns>A new <see cref="LoopItem"/>.</returns>
        public static LoopItem NewFrom(LoopItem? loopItem)
        {
            if (loopItem == null)
            {
                return new LoopItem();
            }

            return new LoopItem()
            {
                Type = loopItem.Type,
                Path = loopItem.Path,
                Order = loopItem.Order,
                Length = loopItem.Length,
            };
        }

        /// <summary>
        /// Copies property values from the given <see cref="LoopItem"/>.
        /// </summary>
        /// <param name="loopItem">The <see cref="LoopItem"/> to copy from.</param>
        public void CopyFrom(LoopItem? loopItem)
        {
            if (loopItem != null)
            {
                this.Order = loopItem.Order;
                this.Path = loopItem.Path;
                this.Type = loopItem.Type;
                this.Length = loopItem.Length;
            }
        }

        /// <summary>
        /// Validates the item against existing items.
        /// </summary>
        /// <param name="existingItems">The existing items.</param>
        /// <returns>A <see cref="ValidationResult"/>.</returns>
        public ValidationResult IsValid(List<LoopItem> existingItems)
        {
            var validationResult = new ValidationResult();

            if (existingItems.Any(i => i.Order == this.Order))
            {
                // TODO Handle if it is an item being edited
                // validationResult.AddError($"An item with order {this.Order} already exists.");
            }

            return validationResult;
        }
    }
}
