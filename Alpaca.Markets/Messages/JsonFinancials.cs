using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Alpaca.Markets
{
    [SuppressMessage(
    "Microsoft.Performance", "CA1812:Avoid uninstantiated internal classes",
    Justification = "Object instances of this class will be created by Newtonsoft.JSON library.")]
    internal class JsonFinancials : IFinancials
    {
        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "results", Required = Required.Always)]
        private JsonFinancialResult[] NestedResults { get; set; }
        public IEnumerable<IFinancialResult> Results => NestedResults;

        [SuppressMessage(
            "Microsoft.Performance", "CA1812:Avoid uninstantiated internal classes",
            Justification = "Object instances of this class will be created by Newtonsoft.JSON library.")]
        internal class JsonFinancialResult : IFinancialResult
        {
            [JsonProperty(PropertyName = "ticker", Required = Required.Always)]
            public string Ticker { get; set; }
            [JsonProperty(PropertyName = "period", Required = Required.Always)]
            public string Period { get; set; }
            [JsonProperty(PropertyName = "returnOnAverageEquity", Required = Required.AllowNull)]
            public decimal? ReturnOnAverageEquity { get; set; }
        }
    }
}
