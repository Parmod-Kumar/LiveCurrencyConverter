using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CurrencyConverter.Base;
using CurrencyConverter.Commands;
using CurrencyConverter.Models;
using CurrencyConverter.WebApiHelper;

namespace CurrencyConverter.ViewModels
{
    /// <summary>
    /// View Model for CurrencyConverterView
    /// </summary>
    public class CurrencyConverterViewModel : ViewModelBase
    {
        #region Private Variables

        /// <summary>
        /// From currencies
        /// </summary>
        private ObservableCollection<Currency> fromCurrencies;

        /// <summary>
        /// To currencies
        /// </summary>
        private ObservableCollection<Currency> toCurrencies;

        /// <summary>
        /// The selected from currency
        /// </summary>
        private Currency selectedFromCurrency;

        /// <summary>
        /// The selected to currency
        /// </summary>
        private Currency selectedToCurrency;

        /// <summary>
        /// From currency text box value
        /// </summary>
        private double fromCurrencyTextBoxValue;

        /// <summary>
        /// To currency text box value
        /// </summary>
        private double toCurrencyTextBoxValue;

        /// <summary>
        /// 
        /// </summary>
        private CurrencyLayer currencyLayer;

        /// <summary>
        /// rates
        /// </summary>
        private Dictionary<string, double> rates;

        /// <summary>
        /// Instance of delegate command
        /// </summary>
        private ICommand fromCurrencyTextBoxPreviewKeyDownCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyConverterViewModel"/> class.
        /// </summary>
        public CurrencyConverterViewModel()
        {
            currencyLayer = new CurrencyLayer();
            FromCurrencies = new ObservableCollection<Currency>();
            var fromCurrencyDetails = currencyLayer.GetSupportedCurrencies();
            foreach (var fromCurrency in fromCurrencyDetails.Currencies)
            {
                FromCurrencies.Add(new Currency
                {
                    Code = fromCurrency.Code,
                    Description = fromCurrency.Description
                });
            }
            ToCurrencies = new ObservableCollection<Currency>();
            var toCurrencyDetails = currencyLayer.GetSupportedCurrencies();
            foreach (var toCurrency in toCurrencyDetails.Currencies)
            {
                ToCurrencies.Add(new Currency
                {
                    Code = toCurrency.Code,
                    Description = toCurrency.Description
                });
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets from currencies.
        /// </summary>
        /// <value>
        /// From currencies.
        /// </value>
        public ObservableCollection<Currency> FromCurrencies
        {
            get => fromCurrencies;
            set
            {
                fromCurrencies = value;
                OnPropertyChanged(nameof(FromCurrencies));
            }
        }

        /// <summary>
        /// Gets or sets to currencies.
        /// </summary>
        /// <value>
        /// To currencies.
        /// </value>
        public ObservableCollection<Currency> ToCurrencies
        {
            get => toCurrencies;
            set
            {
                toCurrencies = value;
                OnPropertyChanged(nameof(ToCurrencies));
            }
        }


        /// <summary>
        /// Gets or sets the selected from currency.
        /// </summary>
        /// <value>
        /// The selected from currency.
        /// </value>
        public Currency SelectedFromCurrency
        {
            get => selectedFromCurrency;
            set
            {
                selectedFromCurrency = value;
                OnPropertyChanged(nameof(SelectedFromCurrency));
                rates = currencyLayer.GetCurrencyRates(SelectedFromCurrency);
                selectedToCurrency.Rate = rates[selectedToCurrency.Code];
                CalculateConversion();
            }
        }

        /// <summary>
        /// Gets or sets the selected to currency.
        /// </summary>
        /// <value>
        /// The selected to currency.
        /// </value>
        public Currency SelectedToCurrency
        {
            get => selectedToCurrency;
            set
            {
                selectedToCurrency = value;
                selectedToCurrency.Rate = rates[selectedToCurrency.Code];
                CalculateConversion();
                OnPropertyChanged(nameof(SelectedToCurrency));
            }
        }

        /// <summary>
        /// Gets or sets from currency text box value.
        /// </summary>
        /// <value>
        /// From currency text box value.
        /// </value>
        public double FromCurrencyTextBoxValue
        {
            get => fromCurrencyTextBoxValue;
            set
            {
                fromCurrencyTextBoxValue = value;
                CalculateConversion();
                OnPropertyChanged(nameof(FromCurrencyTextBoxValue));
            }
        }

        /// <summary>
        /// Gets or sets to currency text box value.
        /// </summary>
        /// <value>
        /// To currency text box value.
        /// </value>
        public double ToCurrencyTextBoxValue
        {
            get => toCurrencyTextBoxValue;
            set
            {
                toCurrencyTextBoxValue = value;
                OnPropertyChanged(nameof(ToCurrencyTextBoxValue));
            }
        }


        #endregion

        #region Command Binding
        public ICommand FromCurrencyTextBoxPreviewKeyDownCommand => this.fromCurrencyTextBoxPreviewKeyDownCommand ?? (this.fromCurrencyTextBoxPreviewKeyDownCommand = new DelegateCommand(obj => CalculateConversion()));

        /// <summary>
        /// 
        /// </summary>
        private void CalculateConversion()
        {
            ToCurrencyTextBoxValue = FromCurrencyTextBoxValue * SelectedToCurrency.Rate;
        }

        #endregion

    }
}
