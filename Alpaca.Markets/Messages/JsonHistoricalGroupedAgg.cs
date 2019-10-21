using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;

namespace Alpaca.Markets
{
    /// <summary>
    /// 
    /// </summary>
    [SuppressMessage(
        "Microsoft.Performance", "CA1812:Avoid uninstantiated internal classes",
        Justification = "Object instances of this class will be created by Newtonsoft.JSON library.")]
    public class JsonHistoricalGroupedAgg : IHistoricalGroupedAgg
    {
        [SuppressMessage(
            "Microsoft.Performance", "CA1812:Avoid uninstantiated internal classes",
            Justification = "Object instances of this class will be created by Newtonsoft.JSON library.")]
        internal sealed class JsonGroupedAgg : IGroupedAgg
        {
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "T", Required = Required.Always)]
            public string Symbol { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "o", Required = Required.Always)]
            public decimal Open { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "h", Required = Required.Always)]
            public decimal High { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "l", Required = Required.Always)]
            public decimal Low { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "c", Required = Required.Always)]
            public decimal Close { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "v", Required = Required.Always)]
            public long Volume { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [JsonIgnore]
            public int ItemsInWindow => throw new NotImplementedException();
            /// <summary>
            /// 
            /// </summary>
            [JsonProperty(PropertyName = "t", Required = Required.Always)]
            public decimal TimeStamp { get; set; }
        }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        public string Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "adjusted", Required = Required.Always)]
        public bool Adjusted { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "queryCount", Required = Required.Always)]
        public long QueryCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "resultsCount", Required = Required.Always)]
        public long ResultsCount { get; set; }

        [JsonProperty(PropertyName = "results", Required = Required.Always)]
        private IEnumerable<JsonGroupedAgg> Aggs { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public IEnumerable<IGroupedAgg> Results { get; set; }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context) =>
            Results = Aggs;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbols"></param>
        public void FilterResults(IEnumerable<string> symbols)
        {
            Results = Aggs.Where(a => symbols.Contains(a.Symbol)).ToList();
        }
    }
}
