// <copyright file="IMainWindowViewModel.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop
{
    using System;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Defines the <see cref="IMainWindowViewModel"/>.
    /// </summary>
    public interface IMainWindowViewModel
    {
        /// <summary>
        /// The action invoked when stopped.
        /// </summary>
        event Action Stopped;

        /// <summary>
        /// Gets or sets the resize mode.
        /// </summary>
        ResizeMode CurrentResizeMode { get; set; }

        /// <summary>
        /// Gets or sets the visibility.
        /// </summary>
        Visibility CurrentVisibility { get; set; }

        /// <summary>
        /// Gets or sets the window state.
        /// </summary>
        WindowState CurrentWindowState { get; set; }

        /// <summary>
        /// Gets or sets the window style.
        /// </summary>
        WindowStyle CurrentWindowStyle { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the window is top most.
        /// </summary>
        bool IsTopmost { get; set; }

        /// <summary>
        /// Gets the OnKeyDownCommand - the command to invoke on key down of the window.
        /// </summary>
        ICommand OnKeyDownCommand { get; }

        /// <summary>
        /// Plays the loop.
        /// </summary>
        void OnPlay();

        /// <summary>
        /// Stops the loop.
        /// </summary>
        void OnStop();
    }
}