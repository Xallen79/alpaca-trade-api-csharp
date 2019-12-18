using System;
using System.Collections.Generic;
using System.Text;

namespace Alpaca.Markets
{
    /// <summary>
    /// 
    /// </summary>
    public interface IFinancialResult
    {
        /// <summary>
        /// 
        /// </summary>
        string Ticker { get; }
        /// <summary>
        /// 
        /// </summary>
        string Period { get; }
        /// <summary>
        /// 
        /// </summary>
        decimal? ReturnOnAverageEquity { get; }

    }
    /// <summary>
    /// 
    /// </summary>
    public interface IFinancials
    {
        /// <summary>
        /// 
        /// </summary>
        string Status { get; }
        /// <summary>
        /// 
        /// </summary>
        IEnumerable<IFinancialResult> Results { get; }

    }
}
