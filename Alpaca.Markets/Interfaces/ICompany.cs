using System;
using System.Collections.Generic;
using System.Text;

namespace Alpaca.Markets
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICompany
    {
        /// <summary>
        /// 
        /// </summary>
        string Country { get; }
        /// <summary>
        /// 
        /// </summary>
        Int64 MarketCap { get; }
        /// <summary>
        /// 
        /// </summary>
        string Symbol { get; }
        /// <summary>
        /// 
        /// </summary>
        string ExchangeSymbol { get; }
    }
}
