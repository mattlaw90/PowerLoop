// <copyright file="IGetSettings.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings.Queries
{
    using PowerLoop.Settings.Models;

    /// <summary>
    /// Defines the <see cref="IGetSettings"/>.
    /// </summary>
    public interface IGetSettings
    {
        /// <summary>
        /// Gets settings from the default save location.
        /// </summary>
        /// <returns>The settings if found.</returns>
        IAppSettings? Execute();
    }
}