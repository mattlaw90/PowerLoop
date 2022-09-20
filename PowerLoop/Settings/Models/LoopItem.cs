// <copyright file="LoopItem.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings.Models
{
    using System.Collections.Generic;
    using System.Linq;

    public class LoopItem : ILoopItem
    {
        /// <summary>
        /// Gets or sets the type of the loop item.
        /// </summary>
        public LoopItemType Type { get; set; }

        /// <summary>
        /// Gets or sets the path to the item - web or path.
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
        /// Gets or sets the file name only.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets a value indicating whether the item is a media type - image or video.
        /// </summary>
        public bool IsMedia => this.Type == LoopItemType.Image || this.Type == LoopItemType.Video;

        /// <inheritdoc/>
        public int? ZoomFactor { get; set; }

        /// <inheritdoc/>
        public int? PixelSkip { get; set; }

        /// <summary>
        /// Returns a new <see cref="LoopItem"/>.
        /// </summary>
        /// <param name="loopItem">The optional <see cref="LoopItem"/> to initialise values from.</param>
        /// <param name="existingItems">The list of existing items.</param>
        /// <returns>A new <see cref="LoopItem"/>.</returns>
        public static LoopItem NewFrom(ILoopItem? loopItem, IEnumerable<ILoopItem> existingItems)
        {
            // Return a new item with a max order + 1, or 1 if there aren't any existing
            if (loopItem == null)
            {
                return new LoopItem()
                {
                    Order = existingItems.NewOrder(),
                    Type = LoopItemType.Image,
                };
            }

            // Return a new object with the same values as the given
            return new LoopItem()
            {
                Type = loopItem.Type,
                Path = loopItem.Path,
                Order = loopItem.Order,
                Length = loopItem.Length,
                ZoomFactor = loopItem.ZoomFactor,
                PixelSkip = loopItem.PixelSkip,
            };
        }

        /// <inheritdoc/>
        public bool CanMoveDown(IEnumerable<ILoopItem> existingItems)
            => this.Order != existingItems.MaxOrder();

        /// <inheritdoc/>
        public bool CanMoveUp(IEnumerable<ILoopItem> existingItems)
            => this.Order != existingItems.MinOrder();

        /// <summary>
        /// Copies property values from the given <see cref="LoopItem"/>.
        /// </summary>
        /// <param name="loopItem">The <see cref="LoopItem"/> to copy from.</param>
        public void CopyFrom(ILoopItem? loopItem)
        {
            if (loopItem != null)
            {
                this.Order = loopItem.Order;
                this.Path = loopItem.Path;
                this.Type = loopItem.Type;
                this.Length = loopItem.Length;
                this.ZoomFactor = loopItem.ZoomFactor;
                this.PixelSkip = loopItem.PixelSkip;
            }
        }

        /// <inheritdoc/>
        public void Decrement(IEnumerable<ILoopItem> existingItems)
        {
            // Get the new order for this item
            var newOrder = this.Order - 1;

            // Get the existing item at this order
            var matchingItem = existingItems.FirstOrDefault(i => i.Order == newOrder);

            // Increment the existing item
            if (matchingItem != null)
            {
                matchingItem.Order++;
            }

            // Decrement this item
            this.Order--;
        }

        /// <inheritdoc/>
        public void Increment(IEnumerable<ILoopItem> existingItems)
        {
            // Get the new order for this item
            var newOrder = this.Order + 1;

            // Get the existing item at this order
            var matchingItem = existingItems.FirstOrDefault(i => i.Order == newOrder);

            // Decrement the existing item
            if (matchingItem != null)
            {
                matchingItem.Order--;
            }

            // Increment this item
            this.Order++;
        }

        /// <summary>
        /// Validates the item against existing items.
        /// </summary>
        /// <param name="existingItems">The existing items.</param>
        /// <returns>A <see cref="ValidationResult"/>.</returns>
        public ValidationResult IsValid(List<ILoopItem> existingItems)
        {
            var validationResult = new ValidationResult();

            if (string.IsNullOrEmpty(this.Path))
            {
                validationResult.AddError($"Path cannot be empty.");
            }

            return validationResult;
        }

        /// <inheritdoc/>
        public void ReOrder(IEnumerable<ILoopItem> existingItems, bool isDeleted = false)
        {
            existingItems
                .Where(i => i != this && i.Order >= this.Order)
                .ToList()
                .ForEach(i => i.Order = isDeleted ? i.Order - 1 : i.Order + 1);
        }
    }
}
