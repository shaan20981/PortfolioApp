using GalaSoft.MvvmLight;
using Mod = Portfolio.Model;
using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using Portfolio.Model.AssetClass;
using System.Windows.Input;


namespace Portfolio.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        private Mod.Portfolio _porfolioModel;
        private string _selectedAssetType;
        private string _priceEntered;
        private string _quantityEntered;
        private int _parsedQuantityEntered;
        private decimal _parsedPriceEntered;


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            

            _porfolioModel = new Mod.Portfolio(new StockFactory());
             AddCommand = new RelayCommand(() => _porfolioModel.AddStock((AssetType)Enum.Parse(typeof(AssetType), _selectedAssetType), _parsedPriceEntered, _parsedQuantityEntered), CanAdd);
           
        }


        public RelayCommand AddCommand { get; private set; }
        public Mod.Portfolio PorfolioModel
        {
            get
            {
              return _porfolioModel;
            }
        }


        public string SelectedAssetType
        {
            get
            {
                return _selectedAssetType;
            }
            set
            {
                if (_selectedAssetType != value)
                {
                    _selectedAssetType = value;                  

                    RaisePropertyChanged("SelectedAssetType");
                    AddCommand.RaiseCanExecuteChanged();
                }
            }
        }


        public string PriceEntered
        {
            get
            {
                return _priceEntered;
            }
            set
            {
                _priceEntered = value;
                RaisePropertyChanged("PriceEntered");
                AddCommand.RaiseCanExecuteChanged();
            }

        }

        public string QuantityEntered
        {
            get
            {
                return _quantityEntered;
            }
            set
            {
                _quantityEntered = value;
                RaisePropertyChanged("QuantityEntered");
                AddCommand.RaiseCanExecuteChanged();            
                
            }

        }

        
        private bool CanAdd()
        {           

            bool quantityValid = int.TryParse(_quantityEntered, out _parsedQuantityEntered);
            bool priceValid = decimal.TryParse(_priceEntered, out _parsedPriceEntered);

            if ((quantityValid) && (priceValid) && _selectedAssetType!=null)
                return true;

            return false;

        }
       
    }
    }