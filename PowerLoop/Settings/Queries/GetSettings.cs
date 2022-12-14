// <copyright file="GetSettings.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings.Queries
{
    using System;
    using System.IO;
    using System.Text.Json;
    using MudBlazor;
    using PowerLoop.AppConfig;
    using PowerLoop.Logging;
    using PowerLoop.Settings.Models;

    public class GetSettings : IGetSettings
    {
        private readonly IConfig config;
        private readonly IAppLogger appLogger;

        public GetSettings(IConfig config, IAppLogger appLogger)
        {
            this.config = config;
            this.appLogger = appLogger;
        }

        public event Action<string, Severity> Notified;

        public IAppSettings? Execute()
        {
            try
            {
                // Return list items parsed from file
                var file = File.ReadAllText(this.config.AppSettingsPath);

                var appSettings = JsonSerializer.Deserialize<AppSettings>(file);

                return appSettings;
            }
            catch (FileNotFoundException ex)
            {
                // Warn on file not found
                this.Notified?.Invoke(ex.Message, Severity.Warning);
            }
            catch (Exception ex)
            {
                // Log any other exception
                this.appLogger.Log(ex);
            }

            return null;
        }
    }
}
