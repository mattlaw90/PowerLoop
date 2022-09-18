// <copyright file="ISaveSettings.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings.Commands
{
    using PowerLoop.Settings.Models;

    /// <summary>
    /// Defines the <see cref="ISaveSettings"/>.
    /// </summary>
    public interface ISaveSettings
    {
        /// <summary>
        /// Saves the settings to a location.
        /// </summary>
        /// <param name="settings">The settings to save.</param>
        /// <returns>The path save dto.</returns>
        string Execute(AppSettings settings);
    }
}