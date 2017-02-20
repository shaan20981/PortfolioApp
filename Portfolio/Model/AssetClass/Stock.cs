using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Model.AssetClass
{
    public abstract class Stock : ObservableObject
    {

        private string _stockName;
        private decimal _price;
        private int _quantity;
        private bool _toleranceBreach;
        protected  int _tolerenceValue;
        private decimal _totalMarketValue;

        public Stock()
        {
            
        }
        public AssetType AssetType { get; protected set; }
        public string StockName
        {
            get
            {
                return _stockName;
            }
            set
            {
               
                Set<string>(() => this.StockName, ref _stockName, value);
            }
        }


        public decimal Price
        {
            get
            {
                return _price;
            }
            set
            {
                if(_price!=value)
                {
                    _price = value;

                    RaisePropertyChanged("Price");
                    NotifyCalculatedFields();
                }                
            }
        }

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;

                    RaisePropertyChanged("Quantity");
                    NotifyCalculatedFields();
                }
            }
        }

        public decimal MarketValue
        {
            get
            {
                return _quantity*_price;
            }
           
        }

        

        //function of marketvalue + total fund value
        public  decimal StockWeight
        {
            get
            {
                if (TotalMarketValue == 0)
                    return 0;

                return (MarketValue / TotalMarketValue);
            }
        }

        public decimal TotalMarketValue
        {
            get
            {
                return _totalMarketValue;
            }
            set
            {
                if (_totalMarketValue != value)
                {
                    _totalMarketValue = value;

                    RaisePropertyChanged("StockWeight");
                   
                }
            }
        }


        public bool ToleranceBreached
        {
            get
            {
                return _toleranceBreach;

            }
            set
            {
                Set<bool>(() => ToleranceBreached, ref _toleranceBreach, value);
            }
        }

        //function of marketvalue 
        public abstract decimal TransactionCost { get; }


        protected void CheckThresholdLevel()
        {
            if (MarketValue < 0 || TransactionCost > _tolerenceValue)
                ToleranceBreached = true;
            else
                ToleranceBreached = false;
        }

        protected void NotifyCalculatedFields()
        {
            RaisePropertyChanged("MarketValue");
            RaisePropertyChanged("TransactionCost");
            RaisePropertyChanged("StockWeight");
            CheckThresholdLevel();
        }

    }
}
