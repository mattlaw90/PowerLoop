// <copyright file="SaveSettings.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings.Commands
{
    using System.IO;
    using System.Linq;
    using System.Text.Json;

    public class SaveSettings
    {
        private readonly Config config;

        public SaveSettings(Config config)
        {
            this.config = config;
        }

        /// <summary>
        /// Saves the settings to a file and returns the path to the file.
        /// </summary>
        /// <param name="settings">The settings to save.</param>
        /// <returns>The file path.</returns>
        public string Execute(AppSettings settings)
        {
            // Get the file name only for media items (images and videos)
            foreach (var item in settings.LoopItems.Where(i => i.IsMedia))
            {
                FileInfo itemFile = new FileInfo(item.Path);
                item.FileName = itemFile.Name;
            }

            // Serialise the settings
            var json = JsonSerializer.Serialize(settings);

            // Create the PowerLoop folder if it doesn't already exist
            FileInfo file = new FileInfo(this.config.AppSettingsPath);
            file?.Directory?.Create();

            // Write the settings - overwriting existing if required
            File.WriteAllText(this.config.AppSettingsPath, json);

            return this.config.AppSettingsPath;
        }
    }
}
