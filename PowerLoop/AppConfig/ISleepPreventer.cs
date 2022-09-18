// <copyright file="ISleepPreventer.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.AppConfig
{
    /// <summary>
    /// Provides functions to prevent sleep.
    /// </summary>
    public interface ISleepPreventer
    {
        /// <summary>
        /// Force the display to be on.
        /// </summary>
        void Start();

        /// <summary>
        /// Return to standard execution state - allow the display to sleep.
        /// </summary>
        void Stop();
    }
}