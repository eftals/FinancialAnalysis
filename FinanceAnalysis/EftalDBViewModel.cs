using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using FinanceAnalysis.POCO;
using System.Windows.Data;


namespace FinanceAnalysis
{
    class EftalDBViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<DailyStockPricePOCO> dStockPriceColl{get ; set ;}
        public ObservableCollection<TickerPOCO> dTickerColl { get; set; }
        YahooStockService yahooReaderInst;
        
        private ICollectionView _dStockPriceView;

        public ICollectionView dStockPriceView
        {
            get { return _dStockPriceView; }
        }
 
  
        
   
        public void RefreshHistory()
        {
            try
            {
                    
                dStockPriceColl.Clear();
                dTickerColl.Clear();
                if (dStockPriceView!=null) dStockPriceView.Refresh();
               
                    
                //populate POCO
                using (var objCtx = new EftalEntities1())
                {


                    objCtx.Tickers.Select(tkr => new TickerPOCO
                    {
                        TickerID = tkr.TickerID,
                        TickerName = tkr.TickerName,
                        LastPrice = 100,
                        Date = DateTime.Now
                    }).ToList().ForEach(b => dTickerColl.Add(b));

                    var list = objCtx.DailyStockPrices.Include("Tickers").Select(a => new DailyStockPricePOCO
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
                    }).ToList();

                    foreach (var item in list)
                    {
                        dStockPriceColl.Add(item);
                    }


                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp);
            }
        }

        public EftalDBViewModel()
        {
            dStockPriceColl= new ObservableCollection<DailyStockPricePOCO>();
            dTickerColl = new ObservableCollection<TickerPOCO>();
            yahooReaderInst = new YahooStockService(Properties.Settings.Default.yhooHist, Properties.Settings.Default.yhooLastPrice);           
 
            RefreshHistory();
              foreach(var item in dTickerColl)
                yahooReaderInst.subscribe(item);

            AddNewCommand = new RelayCommand(AddNew);
            EditCommand = new RelayCommand(Edit);
            UpsertCommand = new RelayCommand(Upsert);
            GetPriceHistoryCommand = new RelayCommand(GetPriceHistory);
            _dStockPriceView = CollectionViewSource.GetDefaultView(dStockPriceColl);
             
        }

        public RelayCommand GetPriceHistoryCommand { get; set; }
        public RelayCommand AddNewCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand UpsertCommand { get; set; }

        void GetPriceHistory(object parameter)
        {
            if (SelectedTicker != null)
            {
                //yahooReaderInst.getStockHistory(SelectedTicker.TickerName);
                RefreshHistory();
            }
        }


        void Upsert(object parameter)
        {
            if (SelectedTicker.TickerID == -1)
            { //add new
                using (EftalEntities1 objCtx = new EftalEntities1())
                {
                    SelectedTicker.TickerID = objCtx.Tickers.Max(a => a.TickerID)+1;

                    objCtx.AddToTickers(new Ticker
                    {
                        TickerID = SelectedTicker.TickerID,
                        TickerName = SelectedTicker.TickerName
                    });
                    objCtx.SaveChanges();
                    dTickerColl.Add(SelectedTicker);
                    yahooReaderInst.subscribe(SelectedTicker);
                }
            }
            else //update old
            {
                var tkr = dTickerColl.Where(a => a.TickerID == SelectedTicker.TickerID).FirstOrDefault();
                tkr.TickerName = SelectedTicker.TickerName;
                using (EftalEntities1 objCtx = new EftalEntities1())
                {
                    var tkrDB = objCtx.Tickers.Where(a => a.TickerID == tkr.TickerID).FirstOrDefault();
                   
                    tkrDB.TickerName = tkr.TickerName;
                    objCtx.SaveChanges();
                }
                
            }
        }


        void AddNew(object parameter)
        {
            SelectedTicker = null; 
            var tkr = new TickerPOCO();
            tkr.TickerID = -1;
            SelectedTicker = tkr;
            showEditModal();
        }

        void showEditModal()
        {
            tkrEdit wnd = new tkrEdit { DataContext = this };
            wnd.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            wnd.ShowDialog();
        }

        void Edit(object parameter)
        {
            if (SelectedTicker != null)
            {
                var tkr = new TickerPOCO { TickerID = SelectedTicker.TickerID,
                                           TickerName = SelectedTicker.TickerName};
                SelectedTicker = tkr;
                showEditModal();
            }
        }

        TickerPOCO _SelectedTicker;
        public TickerPOCO SelectedTicker
        {
            get
            {
                return _SelectedTicker;
            }
            set
            {
                if (_SelectedTicker != value)
                {
                    _SelectedTicker = value;
                   if (_SelectedTicker!=null)
                        dStockPriceView.Filter=((Predicate<object>) delegate(object item)
                        {
                            return (item as DailyStockPricePOCO).TICKER == _SelectedTicker.TickerID;
                        });
                    RaisePropertyChanged("SelectedTicker");
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
