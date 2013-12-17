using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace FinanceAnalysis
{
    class EftalDBViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<DailyStockPricePOCO> dStockPriceColl{get ; set ;}
 
       // public DailyStockPricePOCO selectedTicker = new DailyStockPricePOCO();


        public EftalDBViewModel()
        {
            try
            {
           
                dStockPriceColl = new ObservableCollection<DailyStockPricePOCO>();


                //populate POCO
                using (var objCtx = new EftalEntities1())
                {                 
                    objCtx.DailyStockPrices.Include("Tickers").Select(a => new DailyStockPricePOCO
                    {
                        DailyStockPriceID = a.DailyStockPriceID,
                        TICKER = a.TICKER,
                        tickerName = a.Ticker1.TickerName,
                        Date = a.Date,
                        Open = a.Open,
                        Close = a.Close,
                        Volume = a.Volume,
                        High = a.High,
                        Low = a.Low
                    }).ToList().ForEach(b => dStockPriceColl.Add(b));

                 
                    
                    /*
                    objCtx.DailyStockPrices.Select(a => new DailyStockPricePOCO
                        {
                            DailyStockPriceID = a.DailyStockPriceID,
                            Date = a.Date,
                            Open = a.Open,
                             Close = a.Close,
                             Volume = a.Volume,
                             High = a.High,
                             Low = a.Low
                        }).ToList().ForEach(b => dStockPriceColl.Add(b));*/
                }
            }
            catch (Exception exp)

            {
                Console.WriteLine(exp);
                //throw (exp);
            }
        }



        object _SelectedPerson;
        public object SelectedPerson
        {
            get
            {
                return _SelectedPerson;
            }
            set
            {
                if (_SelectedPerson != value)
                {
                    _SelectedPerson = value;
                    RaisePropertyChanged("SelectedPerson");
                }
            }
        }


        internal void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;

       
    }
}
