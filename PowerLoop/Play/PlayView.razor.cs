// <copyright file="PlayView.razor.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Play
{
    using Microsoft.AspNetCore.Components;

    public partial class PlayView
    {
        [Inject]
        private PlayViewModel PlayViewModel { get; set; }
    }
}
