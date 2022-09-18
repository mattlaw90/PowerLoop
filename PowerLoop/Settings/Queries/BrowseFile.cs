// <copyright file="BrowseFile.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings.Queries
{
    using Microsoft.Win32;

    public class BrowseFile : IBrowseFile
    {
        public string? Execute(string? initialPath = null)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Media Files (*.jpeg, *.png, *.jpg, *.gif, *.mp4)|*.jpeg; *.png; *.jpg; *.gif; *.mp4",
            };

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                return dialog.FileName;
            }

            return null;
        }
    }
}
