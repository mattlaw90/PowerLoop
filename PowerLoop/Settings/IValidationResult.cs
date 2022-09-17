// <copyright file="IValidationResult.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings
{
    using System.Collections.Generic;

    public interface IValidationResult
    {
        bool IsValid { get; set; }

        List<string> Messages { get; }

        void AddError(string message);
    }
}