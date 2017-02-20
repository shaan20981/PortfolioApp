using Microsoft.VisualStudio.TestTools.UnitTesting;
using Portfolio.Model.AssetClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Model.AssetClass.Tests
{
    [TestClass()]
    public class BondTests
    {

        Stock bondStock;
        Stock equityStock;
        decimal price = 20m;
        int quantity = 100;
        decimal totalFundValue = 10000m;


        [TestInitialize]
        public void InitStock()
        {
            IStockFactory stockFactory = new StockFactory();
            bondStock = stockFactory.CreateStock(AssetType.Bond, price, quantity, 0);
            bondStock.TotalMarketValue = totalFundValue;
            equityStock = stockFactory.CreateStock(AssetType.Equity, price, quantity, 0);
            equityStock.TotalMarketValue = totalFundValue;
        }

        [TestMethod()]
        public void MarketValueTest()
        {
            Assert.AreEqual(bondStock.MarketValue, (price * quantity));
            
        }

        [TestMethod()]
        public void StockWeightTest()
        {
            Assert.AreEqual(bondStock.StockWeight, (price * quantity)/totalFundValue );
            
        }

        [TestMethod()]
        public void TotalMarketValueZeroTest()
        {
            bondStock.TotalMarketValue = 0;
            Assert.AreEqual(bondStock.StockWeight, 0);            
        }

        [TestMethod()]
        public void BondTransactionCostTest()
        {            
            Assert.AreEqual(bondStock.TransactionCost, price*quantity*0.02m);
        }

        [TestMethod()]
        public void EquityTransactionCostTest()
        {
            decimal trans = price * quantity * 0.005m;
            Assert.AreEqual(equityStock.TransactionCost,trans);
        }

        [TestMethod()]
        public void EquityTolerenceLvlMarketValueNegativeTest()
        {
            equityStock.Quantity = -quantity;            
            Assert.AreEqual(equityStock.ToleranceBreached, true);
        }

        [TestMethod()]
        public void EquityTolerenceLvlTransactionTest()
        {
            equityStock.Quantity = 200000;
            equityStock.Price = 201;            
            Assert.AreEqual(equityStock.ToleranceBreached, true);
        }

        [TestMethod()]
        public void EquityTolerenceLvlNotBreachTest()
        {
            equityStock.Quantity = 200000;
            equityStock.Price = 200;
            Assert.AreEqual(equityStock.ToleranceBreached, false);
        }

        [TestMethod()]
        public void BondTolerenceLvlTransactionTest()
        {
            bondStock.Quantity = 100000;
            bondStock.Price = 51;            
            Assert.AreEqual(bondStock.ToleranceBreached, true);
        }
        public void BondTolerenceLvlNotBreachTest()
        {
            bondStock.Quantity = 100000;
            bondStock.Price = 50;
            Assert.AreEqual(bondStock.ToleranceBreached, false);
        }

        [TestMethod()]
        public void BondMarketValueTransactionTest()
        {
            bondStock.Quantity = -100000;
            bondStock.Price = 51;
            Assert.AreEqual(bondStock.ToleranceBreached, true);
        }


    }
}