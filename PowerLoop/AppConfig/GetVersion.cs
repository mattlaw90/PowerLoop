// <copyright file="GetVersion.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.AppConfig
{
    using System.Reflection;

    public class GetVersion : IGetVersion
    {
        public string Execute()
        {
            // TODO Get version from click once publish version
            return Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? string.Empty;
        }
    }
}
