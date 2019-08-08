using Alpaca.Markets.Interfaces;
using Newtonsoft.Json;
using System;

namespace Alpaca.Markets
{
    internal class JsonStreamStatus : IStreamStatus
    {
        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        public String Status { get; set; }

        [JsonProperty(PropertyName = "message", Required = Required.Always)]
        public String Message { get; set; }
    }
}
