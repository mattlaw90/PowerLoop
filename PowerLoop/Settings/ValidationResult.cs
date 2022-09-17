// <copyright file="ValidationResult.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings
{
    using System.Collections.Generic;

    public class ValidationResult : IValidationResult
    {
        public bool IsValid { get; set; } = true;

        public List<string> Messages { get; } = new List<string>();

        public void AddError(string message)
        {
            this.IsValid = false;
            this.Messages.Add(message);
        }
    }
}
