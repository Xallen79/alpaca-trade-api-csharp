using Alpaca.Markets.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Alpaca.Markets
{

    internal sealed class JsonTickers : ITickers
    {
        [JsonProperty(PropertyName = "count", Required = Required.Always)]
        public Int64 Count { get; set; }
        [JsonProperty(PropertyName = "status", Required = Required.Always)]
        public string Status { get; set; }
        [JsonProperty(PropertyName = "tickers", Required = Required.Always)]
        public IEnumerable<JsonTicker> RawTickers { get; private set; }
        public IEnumerable<ITicker> Tickers => RawTickers;


    }
    internal sealed class JsonTicker : ITicker
    {
        internal sealed class AggBase : IAggBase
        {
            [JsonProperty(PropertyName = "o", Required = Required.Always)]
            public Decimal Open { get; set; }

            [JsonProperty(PropertyName = "c", Required = Required.Always)]
            public Decimal Close { get; set; }

            [JsonProperty(PropertyName = "l", Required = Required.Always)]
            public Decimal Low { get; set; }

            [JsonProperty(PropertyName = "h", Required = Required.Always)]
            public Decimal High { get; set; }

            [JsonProperty(PropertyName = "v", Required = Required.Always)]
            public Int64 Volume { get; set; }

            public int ItemsInWindow => 0;
        }

        internal sealed class LastTradeBase : IHistoricalTrade
        {
            [JsonProperty(PropertyName = "x", Required = Required.Always)]
            public string Exchange { get; set; }
            [JsonProperty(PropertyName = "t", Required = Required.Always)]
            public long TimeOffset { get; set; }
            [JsonProperty(PropertyName = "p", Required = Required.Always)]
            public decimal Price { get; set; }
            [JsonProperty(PropertyName = "s", Required = Required.Always)]
            public long Size { get; set; }
        }
        internal sealed class LastQuoteBase : IHistoricalQuote
        {
            [JsonProperty(PropertyName = "t", Required = Required.Always)]
            public long TimeOffset { get; set; }

            public string BidExchange => "";

            public string AskExchange => "";

            [JsonProperty(PropertyName = "p", Required = Required.Always)]
            public decimal BidPrice => throw new NotImplementedException();
            [JsonProperty(PropertyName = "P", Required = Required.Always)]
            public decimal AskPrice => throw new NotImplementedException();
            [JsonProperty(PropertyName = "s", Required = Required.Always)]
            public long BidSize => throw new NotImplementedException();
            [JsonProperty(PropertyName = "S", Required = Required.Always)]
            public long AskSize => throw new NotImplementedException();
        }
        [JsonProperty(PropertyName = "ticker", Required = Required.Always)]
        public string Ticker => throw new NotImplementedException();
        [JsonProperty(PropertyName = "day", Required = Required.Always)]
        public AggBase NestedDay { get; set; }
        public IAggBase Day => NestedDay;

        [JsonProperty(PropertyName = "min", Required = Required.Always)]
        public AggBase NestedMin { get; set; }
        public IAggBase Min => NestedMin;

        [JsonProperty(PropertyName = "prevDay", Required = Required.Always)]
        public AggBase NestedPrevDay { get; set; }
        public IAggBase PrevDay => NestedPrevDay;

        [JsonProperty(PropertyName = "lastTrade", Required = Required.Always)]
        public LastTradeBase NestedTrade { get; set; }
        public IHistoricalTrade LastTrade => NestedTrade;

        [JsonProperty(PropertyName = "lastQuote", Required = Required.Always)]
        public LastQuoteBase NestedQuote { get; set; }
        public IHistoricalQuote LastQuote => NestedQuote;

        




        [JsonProperty(PropertyName = "todaysChange", Required = Required.Always)]
        public decimal TodaysChange { get; set; }
        [JsonProperty(PropertyName = "todaysChangePerc", Required = Required.Always)]
        public decimal TodaysChangePerc { get; set; }
        [JsonProperty(PropertyName = "updated", Required = Required.Always)]
        public Int64 Timestamp { get; set; }

        public DateTime Updated { get; private set; }


        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context) =>
            Updated = DateTimeHelper.FromUnixTimeNanoseconds(Timestamp);
    }
}
