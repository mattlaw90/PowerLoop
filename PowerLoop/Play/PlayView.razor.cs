// <copyright file="PlayView.razor.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Play
{
    using Microsoft.AspNetCore.Components;
    using PowerLoop.Settings;

    public partial class PlayView
    {
        [Inject]
        private PlayViewModel PlayViewModel { get; set; }

        [Inject]
        private Config Config { get; set; }
    }
}
