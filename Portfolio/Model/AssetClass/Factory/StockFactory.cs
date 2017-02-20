using Portfolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Model.AssetClass
{
    public enum AssetType
    {
        Equity,
        Bond
    };

    /// <summary>
    /// using a factory here as stocks could be obtained from different sources
    /// </summary>
    public class StockFactory : IStockFactory
    {

       public Stock CreateStock( AssetType assetType, decimal price, int quantity , int occurences)
        {
            Stock stock;
            switch (assetType)
            {
                case AssetType.Bond:
                    {
                       stock = new Bond();
                        break;                        
                    }

                case AssetType.Equity:
                    {
                       stock = new Equity();
                        break;
                    }
                       
                default:
                    throw new Exception("Specify a valid AssetType");
            }


            stock.Price = price;
            stock.Quantity = quantity;
            stock.StockName = assetType.ToString()+ (occurences+1).ToString();
            return stock;
        }       

       
    }
}
