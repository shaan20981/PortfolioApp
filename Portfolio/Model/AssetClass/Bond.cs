using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Model.AssetClass
{
    public class Bond:Stock
    {

        public Bond()
        {
            //Any additonal stuff goes here
            AssetType = AssetType.Bond;
            _tolerenceValue = 100000;
        }

        public override decimal TransactionCost
        {
            get
            {
                return MarketValue * (2m / 100);
            }

        }


    }
}
