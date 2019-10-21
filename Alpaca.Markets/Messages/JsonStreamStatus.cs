using Alpaca.Markets.Interfaces;
using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Alpaca.Markets
{
    [SuppressMessage(
    "Microsoft.Performance", "CA1812:Avoid uninstantiated internal classes",
    Justification = "Object instances of this class will be created by Newtonsoft.JSON library.")]
    internal class JsonStreamStatus : IStreamStatus
    {
        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        public String Status { get; set; }

        [JsonProperty(PropertyName = "message", Required = Required.Always)]
        public String Message { get; set; }
    }
}
