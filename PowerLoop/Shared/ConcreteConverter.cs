// <copyright file="ConcreteConverter.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Shared
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public class ConcreteConverter<TType, TInterface> : JsonConverter<TInterface>
    {
        /// <summary>
        /// Gets a value indicating whether nulls are handled.
        /// </summary>
        public override bool HandleNull => true;

        /// <summary>
        /// Deserializes the json into the derived type.
        /// </summary>
        /// <param name="reader">The json reader.</param>
        /// <param name="typeToConvert">The type - interface.</param>
        /// <param name="options">The options.</param>
        /// <returns>A nullable <see cref="TInterface"/>.</returns>
        public override TInterface? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            => (TInterface?)JsonSerializer.Deserialize(JsonDocument.ParseValue(ref reader), typeof(TType), options);

        /// <summary>
        /// Serializes the object into a derived type.
        /// </summary>
        /// <param name="writer">The json writer.</param>
        /// <param name="value">The interface type.</param>
        /// <param name="options">The json serializer options.</param>
        public override void Write(Utf8JsonWriter writer, TInterface value, JsonSerializerOptions options)
            => JsonSerializer.Serialize(writer, value, typeof(TType), options);
    }
}
