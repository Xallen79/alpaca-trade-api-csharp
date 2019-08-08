using System;
using System.Collections.Generic;
using System.Text;

namespace Alpaca.Markets.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IStreamStatus
    {
        /// <summary>
        /// 
        /// </summary>
        String Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        String Status { get; set; }
    }

}
