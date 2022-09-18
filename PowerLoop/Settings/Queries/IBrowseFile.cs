// <copyright file="IBrowseFile.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings.Queries
{
    /// <summary>
    /// Defines the <see cref="IBrowseFile"/>.
    /// </summary>
    public interface IBrowseFile
    {
        /// <summary>
        /// Browses for a file and returns the path if selected.
        /// </summary>
        /// <param name="initialPath"></param>
        /// <returns></returns>
        string? Execute(string? initialPath = null);
    }
}