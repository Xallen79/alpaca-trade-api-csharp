using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alpaca.Markets
{
    internal class JsonCompany : ICompany
    {
        [JsonProperty(PropertyName = "country", Required = Required.Always)]
        public string Country { get; set; }
        [JsonProperty(PropertyName = "marketCap", Required = Required.Always)]
        public long MarketCap { get; set; }
        [JsonProperty(PropertyName = "symbol", Required = Required.Always)]
        public string Symbol { get; set; }
        [JsonProperty(PropertyName = "exchangeSymbol", Required = Required.Always)]
        public string ExchangeSymbol { get; set; }
    }
}
