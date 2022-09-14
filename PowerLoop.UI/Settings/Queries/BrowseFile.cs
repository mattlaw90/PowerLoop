// <copyright file="BrowseFile.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.UI.Settings.Queries
{
    using Microsoft.Win32;

    public class BrowseFile
    {
        public string? Execute(string? initialPath = null)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|MP4 Files (*.mp4)|*.mp4",
            };

            dialog.InitialDirectory = initialPath ?? dialog.InitialDirectory;
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                return dialog.FileName;
            }

            return null;
        }
    }
}
