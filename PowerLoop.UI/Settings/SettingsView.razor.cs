// <copyright file="SettingsView.razor.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.UI.Settings
{
    using Microsoft.AspNetCore.Components;

    public partial class SettingsView
    {
        [Inject]
        private SettingsViewModel SettingsViewModel { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                this.SettingsViewModel.OnGet();
            }
        }
    }
}
