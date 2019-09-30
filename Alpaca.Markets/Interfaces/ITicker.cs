using System;
using System.Collections.Generic;
using System.Text;

namespace Alpaca.Markets
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITickers
    {
        /// <summary>
        /// 
        /// </summary>
        Int64 Count { get;  }

        /// <summary>
        /// 
        /// </summary>
        string Status { get; }

        /// <summary>
        /// 
        /// </summary>
        IEnumerable<ITicker> Tickers { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public interface ITicker
    {
        /// <summary>
        /// 
        /// </summary>
        string Ticker { get; }
        /// <summary>
        /// 
        /// </summary>
        IAggBase Day { get; }
        /// <summary>
        /// 
        /// </summary>
        IHistoricalTrade LastTrade { get; }
        /// <summary>
        /// 
        /// </summary>
        IHistoricalQuote LastQuote { get;  }
        /// <summary>
        /// 
        /// </summary>
        IAggBase Min { get; }
        /// <summary>
        /// 
        /// </summary>
        IAggBase PrevDay { get; }
        /// <summary>
        /// 
        /// </summary>
        decimal TodaysChange { get; }
        /// <summary>
        /// 
        /// </summary>
        decimal TodaysChangePerc { get;  }
        /// <summary>
        /// 
        /// </summary>
        Int64 Timestamp { get; }
        /// <summary>
        /// 
        /// </summary>
        DateTime Updated { get; }

    }
}
