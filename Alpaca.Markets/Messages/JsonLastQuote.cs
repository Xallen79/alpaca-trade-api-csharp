using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Alpaca.Markets
{
    [SuppressMessage(
        "Microsoft.Performance", "CA1812:Avoid uninstantiated internal classes",
        Justification = "Object instances of this class will be created by Newtonsoft.JSON library.")]
    internal sealed class JsonLastQuote : ILastQuote
    {
        internal sealed class Last
        {
            [JsonProperty(PropertyName = "x", Required = Required.Always)]
            public Int64 BidExchange { get; set; }

            [JsonProperty(PropertyName = "X", Required = Required.Always)]
            public Int64 AskExchange { get; set; }

            [JsonProperty(PropertyName = "p", Required = Required.Default)]
            public Decimal BidPrice { get; set; }

            [JsonProperty(PropertyName = "P", Required = Required.Default)]
            public Decimal AskPrice { get; set; }

            [JsonProperty(PropertyName = "s", Required = Required.Default)]
            public Int64 BidSize { get; set; }

            [JsonProperty(PropertyName = "S", Required = Required.Default)]
            public Int64 AskSize { get; set; }

            [JsonProperty(PropertyName = "t", Required = Required.Always)]
            public Int64 Timestamp { get; set; }

            [JsonProperty(PropertyName="T", Required = Required.Always)]
            public String Symbol { get; set; }
        }

        [JsonProperty(PropertyName = "results", Required = Required.Always)]
        public Last Nested { get; set; }

        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        public String Status { get; set; }

        [JsonIgnore]
        public String Symbol => Nested.Symbol;

        [JsonIgnore]
        public Int64 BidExchange => Nested.BidExchange;

        [JsonIgnore]
        public Int64 AskExchange => Nested.AskExchange;

        [JsonIgnore]
        public Decimal BidPrice => Nested.BidPrice;

        [JsonIgnore]
        public Decimal AskPrice => Nested.AskPrice;

        [JsonIgnore]
        public Int64 BidSize => Nested.BidSize;

        [JsonIgnore]
        public Int64 AskSize => Nested.AskSize;

        [JsonIgnore]
        public DateTime Time { get; private set; }

        [OnDeserialized]
        internal void OnDeserializedMethod(
            StreamingContext context) =>
            Time = DateTimeHelper.FromUnixTimeNanoseconds(Nested.Timestamp);
    }
}
