using System;
using System.Collections.Generic;
using System.Text;

namespace Alpaca.Markets
{
    /// <summary>
    /// 
    /// </summary>
    public interface IGroupedAgg : IAggBase
    {
        /// <summary>
        /// 
        /// </summary>
        string Symbol { get; }
    }
    /// <summary>
    /// 
    /// </summary>
    public interface IHistoricalGroupedAgg
    {
        /// <summary>
        /// 
        /// </summary>
        string Status { get; }
        /// <summary>
        /// 
        /// </summary>
        Int64 QueryCount { get; }
        /// <summary>
        /// 
        /// </summary>
        Int64 ResultsCount { get; }
        /// <summary>
        /// 
        /// </summary>
        bool Adjusted { get; }
        /// <summary>
        /// 
        /// </summary>
        IEnumerable<IGroupedAgg> Results { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="symbols"></param>
        void FilterResults(IEnumerable<string> symbols);
    }
}
