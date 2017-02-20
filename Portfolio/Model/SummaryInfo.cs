using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Model
{
    public class SummaryInfo : ObservableObject
    {
       
        private int _totalQuantity;
        private decimal _totalStockWeight;
        private decimal _totalMarketValue;

        public string Type { get; set; }
        public int TotalQuantity
        {
            get
            {
                return _totalQuantity;
            }
            set
            {

                Set<int>(() => this.TotalQuantity, ref _totalQuantity, value);
            }
        }

        public decimal  TotalStockWeight
        {
            get
            {
                return _totalStockWeight;
            }
            set
            {

                Set<decimal>(() => this.TotalStockWeight, ref _totalStockWeight, value);
            }
        }

        public decimal  TotalMarketValue
        {
            get
            {
                return _totalMarketValue;
            }
            set
            {

                Set<decimal>(() => this.TotalMarketValue, ref _totalMarketValue, value);
            }
        }


    }
}
