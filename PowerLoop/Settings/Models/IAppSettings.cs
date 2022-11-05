// <copyright file="IAppSettings.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings.Models
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using PowerLoop.Shared;

    [JsonConverter(typeof(ConcreteConverter<AppSettings, IAppSettings>))]
    public interface IAppSettings
    {
        /// <summary>
        /// Gets or sets the index of the item to start at - if available.
        /// </summary>
        int StartItem { get; set; }

        /// <summary>
        /// Gets or sets the value (in seconds) to stay on an item by default - overridden by individual item intervals if set.
        /// </summary>
        int DefaultInterval { get; set; }

        /// <summary>
        /// Gets or sets the collection of items to loop through.
        /// </summary>
        List<ILoopItem> LoopItems { get; set; }
    }
}