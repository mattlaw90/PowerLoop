// <copyright file="LoopItemDialog.razor.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.UI.Settings
{
    using System.Collections.Generic;
    using System.Windows.Documents;
    using Microsoft.AspNetCore.Components;
    using MudBlazor;

    public partial class LoopItemDialog
    {
        private LoopItem localLoopItem;

        [Inject]
        private ISnackbar Snackbar { get; set; }

        [CascadingParameter]
        MudDialogInstance MudDialog { get; set; }

        [Parameter]
        public LoopItem? LoopItem { get; set; }

        [Parameter]
        public List<LoopItem> ExistingItems { get; set; }

        protected override void OnParametersSet()
        {
            this.localLoopItem = LoopItem.NewFrom(this.LoopItem);
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
    }
}
