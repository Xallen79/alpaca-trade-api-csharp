﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Alpaca.Markets
{
    [SuppressMessage(
        "Microsoft.Performance", "CA1812:Avoid uninstantiated internal classes",
        Justification = "Object instances of this class will be created by Newtonsoft.JSON library.")]
    internal sealed class JsonLastTrade : ILastTrade
    {
        internal sealed class Last
        {
            [JsonProperty(PropertyName = "x", Required = Required.Always)]
            public Int64 Exchange { get; set; }

            [JsonProperty(PropertyName = "p", Required = Required.Always)]
            public Decimal Price { get; set; }

            [JsonProperty(PropertyName = "s", Required = Required.Always)]
            public Int64 Size { get; set; }

            [JsonProperty(PropertyName = "t", Required = Required.Always)]
            public Int64 Timestamp { get; set; }

            [JsonProperty(PropertyName = "T", Required = Required.Always)]
            public String Symbol { get; set; }
        }

        [JsonProperty(PropertyName = "results", Required = Required.Always)]
        public Last Nested { get; set; }

        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        public String Status { get; set; }

        [JsonIgnore]
        public String Symbol => Nested.Symbol;

        [JsonIgnore]
        public Int64 Exchange => Nested.Exchange;

        [JsonIgnore]
        public Decimal Price => Nested.Price;

        [JsonIgnore]
        public Int64 Size => Nested.Size;

        [JsonIgnore]
        public DateTime Time { get; private set; }

        [OnDeserialized]
        internal void OnDeserializedMethod(
            StreamingContext context)
        {
            Time = DateTimeHelper.FromUnixTimeNanoseconds(Nested.Timestamp);
        }
    }
}
