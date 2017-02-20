using GalaSoft.MvvmLight;
using Portfolio.Model.AssetClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Model
{
   
    /// <summary>
    /// This is model for the fund portfolio. It contains all the necessary methods and objects required for managing a portfolio
    /// A stockfactory is injected as stocks could be "created" / retrieved from different sources or markets 
    /// 
    /// </summary>
    public class Portfolio : ObservableObject
    {

        private ObservableCollection<Stock> _stocksCollections;
        private ObservableCollection<SummaryInfo> _summaryInfoCollections;
        private IStockFactory _stockFactory;

        public Portfolio(IStockFactory stockFactory)
        {
            _stocksCollections = new ObservableCollection<Stock>();
            _summaryInfoCollections = new ObservableCollection<SummaryInfo>();
            _stockFactory = stockFactory;
        }


        public void AddStock(AssetType assetType, decimal price, int quantity)
        {            
            Stock stock = _stockFactory.CreateStock(assetType, price, quantity, _stocksCollections.Where(x => x.AssetType == assetType).Count());
            _stocksCollections.Add(stock);            
            UpdateStockTotalValueFund();
            CalculateSummaryInfo();
        }
        
        private void CalculateSummaryInfo()
        {
            foreach (AssetType assetType in Enum.GetValues(typeof(AssetType)))
            {            

                SummaryInfo summaryInfo = _summaryInfoCollections.Where(x => x.Type == assetType.ToString()).FirstOrDefault();

                if (summaryInfo == null)
                {
                    summaryInfo = new SummaryInfo() { Type = assetType.ToString() };
                    _summaryInfoCollections.Add(summaryInfo);
                }
                AssetType currentAssetType = assetType;
                var assetChoice = _stocksCollections.Where(x => x.AssetType == currentAssetType);
                summaryInfo.TotalQuantity = assetChoice.Sum(y => y.Quantity);               
                summaryInfo.TotalStockWeight = assetChoice.Sum(y => y.StockWeight);
                summaryInfo.TotalMarketValue = assetChoice.Sum(y => y.MarketValue);

            }

            String TotalCol = "Total";
            SummaryInfo summaryTotal = _summaryInfoCollections.Where(x => x.Type == TotalCol).FirstOrDefault();
            if (summaryTotal == null)
            {
                summaryTotal = new SummaryInfo() {  Type = TotalCol };
                _summaryInfoCollections.Add(summaryTotal);
            }
            
            summaryTotal.TotalQuantity = _stocksCollections.Sum(y => y.Quantity);
            summaryTotal.TotalMarketValue = _stocksCollections.Sum(y => y.MarketValue);
            summaryTotal.TotalStockWeight = _stocksCollections.Sum(y => y.StockWeight);
        }

        private void UpdateStockTotalValueFund()
        {
            decimal totalFundValue = _stocksCollections.Sum(x => x.MarketValue);

            foreach (Stock stock in _stocksCollections)
            {
                stock.TotalMarketValue = totalFundValue;
            }
        }
        public ObservableCollection<Stock> StocksCollections
        {
            get
            {
                return _stocksCollections;
            }

            private set
            {
                _stocksCollections = value;
            }
        }

        public ObservableCollection<SummaryInfo> SummaryInfoCollections
        {
            get
            {
                return _summaryInfoCollections;
            }

            private set
            {
                _summaryInfoCollections = value;
            }
        }
    }
}
