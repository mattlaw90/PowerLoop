// <copyright file="ISettingsReader.cs" company="Matthew Law">
// Copyright (c) Matthew Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings
{
    using System;

    public interface ISettingsReader
    {
        T Load<T>() where T : class, new();

        T LoadSection<T>() where T : class, new();

        object Load(Type type);

        object LoadSection(Type type);
    }
}
