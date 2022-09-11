// <copyright file="SettingsReader.cs" company="Matthew Law">
// Copyright (c) Matthew Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings
{
    using System;
    using System.IO;
    using System.Text.Json;

    public class SettingsReader : ISettingsReader
    {
        private readonly string configurationFilePath;
        private readonly string sectionNameSuffix;

        public SettingsReader(string configurationFilePath, string sectionNameSuffix)
        {
            this.configurationFilePath = configurationFilePath;
            this.sectionNameSuffix = sectionNameSuffix;
        }

        public T Load<T>()
            where T : class, new() => this.Load(typeof(T)) as T;

        public object Load(Type type)
        {
            if (!File.Exists(this.configurationFilePath))
            {
                return Activator.CreateInstance(type);
            }

            var jsonFile = File.ReadAllText(this.configurationFilePath);

            return JsonSerializer.Deserialize(jsonFile, type);
        }

        public T LoadSection<T>()
            where T : class, new() => this.LoadSection(typeof(T)) as T;

        public object LoadSection(Type type)
        {
            if (!File.Exists(this.configurationFilePath))
            {
                return Activator.CreateInstance(type);
            }

            var jsonFile = File.ReadAllText(this.configurationFilePath);
            var section = ToCamelCase(type.Name.Replace(this.sectionNameSuffix, string.Empty));
            var settingsData = JsonSerializer.Deserialize<dynamic>(jsonFile);
            var settingsSection = settingsData[section];

            return settingsSection == null
                ? Activator.CreateInstance(type)
                : JsonSerializer.Deserialize(JsonSerializer.Serialize(settingsSection), type);
        }

        private static string ToCamelCase(string text)
            => string.IsNullOrWhiteSpace(text)
                ? string.Empty
                : $"{text[0].ToString().ToLowerInvariant()}{text[1..]}";
    }
}
