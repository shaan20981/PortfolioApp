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
    public class StockFactoryTests
    {
        [TestMethod()]
        public void CreateEquityTest()
        {
            StockFactory stockFactory = new StockFactory();
            AssetType type = AssetType.Equity;
            decimal price = 20;
            int quantity = 1;
            int occurence = 0;
            Stock s = stockFactory.CreateStock(type, price, quantity, occurence);
            Assert.AreEqual(s.AssetType,type);
            Assert.AreEqual(s.Price , price);
            Assert.AreEqual(s.Quantity,quantity);
            Assert.AreEqual(s.StockName, type.ToString() + (occurence + 1).ToString());
            Assert.IsTrue(s.GetType() == typeof(Equity));

        }

        [TestMethod()]
        public void CreateBondTest()
        {
            StockFactory stockFactory = new StockFactory();
            AssetType type = AssetType.Bond;
            decimal price = 20;
            int quantity = 1;
            int occurence = 0;
            Stock s = stockFactory.CreateStock(type, price, quantity, occurence);
            Assert.AreEqual(s.AssetType, type);
            Assert.AreEqual(s.Price, price);
            Assert.AreEqual(s.Quantity, quantity);
            Assert.AreEqual(s.StockName, type.ToString() + (occurence + 1).ToString());
            Assert.IsTrue(s.GetType() == typeof(Bond));

        }
    }
}