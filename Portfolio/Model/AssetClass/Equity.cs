using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Model.AssetClass
{
    public class Equity : Stock
    {
        public Equity()
        {
            //Any additonal stuff goes here
            AssetType = AssetType.Equity;
            _tolerenceValue = 200000;
        }
        public override decimal TransactionCost
        {
            get
            {
                return MarketValue * (0.5m / 100);
            }
            
        }       

    }
}
