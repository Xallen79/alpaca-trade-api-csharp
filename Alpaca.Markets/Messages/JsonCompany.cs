using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace Alpaca.Markets
{
    [SuppressMessage(
    "Microsoft.Performance", "CA1812:Avoid uninstantiated internal classes",
    Justification = "Object instances of this class will be created by Newtonsoft.JSON library.")]
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
