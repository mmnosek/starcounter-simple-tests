using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Starcounter.Nova;

namespace SCNova.Models
{
    [Database]
    public abstract class StockTrade
    {
        [Index]
        public abstract string StockSymbol { get; set; }
        [Index]
        public abstract int Amount { get; set; }
    }
}
