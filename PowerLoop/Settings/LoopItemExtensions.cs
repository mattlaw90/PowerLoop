// <copyright file="LoopItemExtensions.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings
{
    using System.Collections.Generic;
    using System.Linq;

    public static class LoopItemExtensions
    {
        /// <summary>
        /// Returns the maximum order value of the collection of items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>1 if no items.</returns>
        public static int MaxOrder(this IEnumerable<LoopItem> items)
            => items.Any() ? items.Select(i => i.Order).Max() : 1;

        /// <summary>
        /// Returns the minimum order value of the collection of items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns>1 if no items.</returns>
        public static int MinOrder(this IEnumerable<LoopItem> items)
            => items.Any() ? items.Select(i => i.Order).Min() : 1;
    }
}
