using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portfolio.Model;
using Portfolio.Model.AssetClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Model.Tests
{
    [TestClass()]
    public class PortfolioTests
    {

        Portfolio portfolio;

        [TestInitialize()]
        public void PortfolioTest()
        {
            portfolio = new Portfolio(new StockFactory());
        }

        [TestMethod()]
        public void CheckCollectionsValidTest()
        {
            Assert.IsNotNull(portfolio.StocksCollections);
            Assert.IsNotNull(portfolio.SummaryInfoCollections);
        }


        [TestMethod()]
        public void AddStockTest()
        {
            AssetType assetType = AssetType.Bond;
            int quantity = 100;
            decimal price = 19.2m;
            portfolio.AddStock(assetType, price, quantity);
            Assert.IsTrue(portfolio.StocksCollections.Count == 1);
            Assert.IsTrue(portfolio.SummaryInfoCollections.Count > 0);

            Stock stock = portfolio.StocksCollections.First();
            Assert.AreEqual(stock.AssetType, assetType);
            Assert.AreEqual(stock.Price, price);
            Assert.AreEqual(stock.Quantity, quantity);
            
        }

        [TestMethod()]
        public void StockTotalWeightTest()
        {
            AssetType assetTypeEquity = AssetType.Equity;
            int quantity = 100;
            decimal price = 10m;
            portfolio.AddStock(assetTypeEquity, price, quantity);

            Assert.IsTrue(portfolio.StocksCollections.Count == 1);

            Stock equity = portfolio.StocksCollections.Where(x => x.AssetType == assetTypeEquity).First();

            Assert.AreEqual(equity.TotalMarketValue, quantity * price);
            Assert.AreEqual(equity.StockWeight, 1m);

            AssetType assetTypeBond = AssetType.Bond;
            int quantityBond = 100;
            decimal priceBond = 10m;
            portfolio.AddStock(assetTypeBond, priceBond, quantityBond);

            Stock bond = portfolio.StocksCollections.Where(x => x.AssetType == assetTypeBond).First();

            decimal totalMarketValue = (quantity * price) + (priceBond * quantityBond);

            Assert.AreEqual(equity.TotalMarketValue, totalMarketValue);
            Assert.AreEqual(equity.StockWeight,  (quantity * price)/ totalMarketValue  );

            Assert.AreEqual(bond.TotalMarketValue, totalMarketValue);
            Assert.AreEqual(bond.StockWeight,  (priceBond * quantityBond)/ totalMarketValue );
            
       }



        [TestMethod()]
        public void CheckSumamaryTest()
        {
            AssetType assetType = AssetType.Bond;
            int quantity = 100;
            decimal price = 100m;
            portfolio.AddStock(assetType, price, quantity);
                        
            SummaryInfo bondSummary = portfolio.SummaryInfoCollections.Where(x => x.Type == AssetType.Bond.ToString()).First();
            Assert.AreEqual(bondSummary.TotalMarketValue, quantity*price);
            Assert.AreEqual(bondSummary.TotalQuantity, quantity );
            Assert.AreEqual(bondSummary.TotalStockWeight, 1);
            
            AssetType assetTypeEquity = AssetType.Equity;
            int quantityEquity = 100;
            decimal priceEquity = 100m;
            portfolio.AddStock(assetTypeEquity, priceEquity, quantityEquity);

            Assert.AreEqual(bondSummary.TotalStockWeight, 0.5m);
            SummaryInfo equitySummary = portfolio.SummaryInfoCollections.Where(x => x.Type == AssetType.Equity.ToString()).First();
            Assert.AreEqual(equitySummary.TotalStockWeight, 0.5m);
            Assert.AreEqual(equitySummary.TotalQuantity, quantityEquity);
            Assert.AreEqual(equitySummary.TotalMarketValue, quantityEquity*priceEquity);

            SummaryInfo totalSummary = portfolio.SummaryInfoCollections.Where(x => x.Type == "Total").First();
            Assert.AreEqual(totalSummary.TotalStockWeight, 1m);
            Assert.AreEqual(totalSummary.TotalQuantity, quantityEquity+quantity);
            Assert.AreEqual(totalSummary.TotalMarketValue, (2*(quantityEquity * priceEquity)));

        }


    }
}