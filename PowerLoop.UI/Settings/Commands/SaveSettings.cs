// <copyright file="SaveSettings.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.UI.Settings.Commands
{
    using System;
    using System.IO;
    using System.Text.Json;

    public class SaveSettings
    {
        /// <summary>
        /// Saves the settings to a file and returns the path to the file.
        /// </summary>
        /// <param name="settings">The settings to save.</param>
        /// <returns>The file path.</returns>
        public string Execute(AppSettings settings)
        {
            var json = JsonSerializer.Serialize(settings);

            string path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "powerloop-appsettings.json");

            File.WriteAllText(path, json);

            return path;
        }
    }
}
