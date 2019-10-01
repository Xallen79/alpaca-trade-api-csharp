using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alpaca.Markets
{
    internal class JsonFinancials : IFinancials
    {
        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "results", Required = Required.Always)]
        private JsonFinancialResult[] NestedResults { get; set; }
        public IEnumerable<IFinancialResult> Results => NestedResults;

        internal class JsonFinancialResult : IFinancialResult
        {
            [JsonProperty(PropertyName = "ticker", Required = Required.Always)]
            public string Ticker { get; set; }
        }
    }
}
