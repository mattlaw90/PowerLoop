// <copyright file="LoopItemDialog.razor.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Components;
    using MudBlazor;
    using PowerLoop.Settings.Models;
    using PowerLoop.Settings.Queries;

    public partial class LoopItemDialog
    {
        private LoopItem localLoopItem;

        [Inject]
        private ISnackbar Snackbar { get; set; }

        [Inject]
        private IBrowseFile BrowseFile { get; set; }

        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public ILoopItem? Item { get; set; }

        [Parameter]
        public List<ILoopItem> ExistingItems { get; set; }

        protected override void OnParametersSet()
        {
            this.localLoopItem = LoopItem.NewFrom(this.Item, this.ExistingItems);
        }

        private void Submit()
        {
            // Validate the item against existing items
            var validationResult = this.localLoopItem.IsValid(this.ExistingItems);

            // If valid, return it to be used, otherwise warn with the validation messages
            if (validationResult.IsValid)
            {
                this.MudDialog.Close(this.localLoopItem);
            }
            else
            {
                validationResult.Messages.ForEach(m => this.Snackbar.Add(m, Severity.Warning));
            }
        }

        private void Cancel() => this.MudDialog.Cancel();

        private void OnSearch()
        {
            var selectedFilePath = this.BrowseFile.Execute(this.localLoopItem.Path);

            if (!string.IsNullOrEmpty(selectedFilePath))
            {
                this.localLoopItem.Path = selectedFilePath;
            }
        }
    }
}
