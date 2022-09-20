// <copyright file="SnackBus.razor.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Shared
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Components;
    using MudBlazor;

    public partial class SnackBus : IDisposable
    {
        [Inject]
        private ISnackbar Snackbar { get; set; }

        [Inject]
        private IEnumerable<INotifier> Notifiers { get; set; }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Unsubscribe from each notifier.
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var n in this.Notifiers)
                {
                    n.Notified -= this.Notify;
                }
            }
        }

        /// <summary>
        /// Subscribes to each notifiers notify event.
        /// </summary>
        protected override void OnInitialized()
        {
            foreach (var n in this.Notifiers)
            {
                n.Notified += this.Notify;
            }
        }

        private void Notify(string message, Severity severity)
        {
            // Get snacks with the same message and severity
            var sameSnacks = this.Snackbar.ShownSnackbars
                .Where(x => x.Message == message && x.Severity == severity)
                .ToList();

            // Remove the matching snacks to not spam
            sameSnacks.ForEach(s => this.Snackbar.Remove(s));

            // Add the new snack
            this.Snackbar.Add(message, severity);
        }
    }
}
