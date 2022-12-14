// <copyright file="SettingsView.razor.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using MudBlazor;
    using PowerLoop.AppConfig;
    using PowerLoop.Settings.Models;

    public partial class SettingsView
    {
        private bool pathDisplayOpen;

        [Inject]
        private IConfig Config { get; set; }

        [Inject]
        private IDialogService DialogService { get; set; }

        [Inject]
        private ISettingsViewModel SettingsViewModel { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                this.SettingsViewModel.OnGet();
            }
        }

        private async Task OnAdd()
        {
            // Open the dialog with existing item
            var dialogParameters = new DialogParameters
            {
                { nameof(LoopItemDialog.ExistingItems), this.SettingsViewModel.LoopItems },
            };

            var dialogOptions = new DialogOptions()
            {
                MaxWidth = MaxWidth.ExtraLarge,
                CloseButton = false,
                FullWidth = true,
                CloseOnEscapeKey = false,
                DisableBackdropClick = true,
            };

            // Open the dialog with new item
            var dialog = this.DialogService.Show<LoopItemDialog>($"Add Item", dialogParameters, dialogOptions);
            var result = await dialog.Result;

            // Add on VM
            if (result.Data is LoopItem li)
            {
                this.SettingsViewModel.OnAdd(li);
            }
        }

        private async Task OnEdit(ILoopItem loopItem)
        {
            // Open the dialog with existing item
            var dialogParameters = new DialogParameters
            {
                { nameof(LoopItemDialog.Item), loopItem },
                { nameof(LoopItemDialog.ExistingItems), this.SettingsViewModel.LoopItems },
            };

            var dialogOptions = new DialogOptions()
            {
                MaxWidth = MaxWidth.ExtraLarge,
                CloseButton = false,
                FullWidth = true,
                CloseOnEscapeKey = false,
                DisableBackdropClick = true,
            };

            var dialog = this.DialogService.Show<LoopItemDialog>($"Edit Item", dialogParameters, dialogOptions);
            var result = await dialog.Result;

            // Add on VM
            if (result.Data is LoopItem li)
            {
                loopItem.CopyFrom(li);
                this.SettingsViewModel.OnSave();
            }
        }

        private async Task OnDelete(ILoopItem loopItem)
        {
            // Prompt
            bool? result = await this.DialogService.ShowMessageBox(
                "Delete",
                $"Delete {loopItem.Path}?",
                yesText: "Delete!",
                cancelText: "Cancel");

            // Delete
            if (result == true)
            {
                this.SettingsViewModel.OnDelete(loopItem);
            }
        }
    }
}
