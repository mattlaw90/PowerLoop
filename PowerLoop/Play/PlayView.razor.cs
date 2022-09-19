// <copyright file="PlayView.razor.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Play
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Web;
    using MudBlazor;
    using PowerLoop.AppConfig;

    public partial class PlayView
    {
        [Inject]
        private IPlayViewModel PlayViewModel { get; set; }

        [Inject]
        private IConfig Config { get; set; }
    }
}
