using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace FinanceAnalysis
{
    class DailyStockPricePOCO:DependencyObject
    {

     
     /*
        DailyStockPrice dailyStockPrice = new DailyStockPrice();
            dailyStockPrice.DailyStockPriceID = dailyStockPriceID;
            dailyStockPrice.TICKER = tICKER;
            dailyStockPrice.Date = date;
            dailyStockPrice.Open = open;
            dailyStockPrice.High = high;
            dailyStockPrice.Low = low;
            dailyStockPrice.Close = close;
            dailyStockPrice.Volume = volume;
            dailyStockPrice.adjClose = adjClose;
            return dailyStockPrice;
        */





        public double Open
        {
            get { return (double)GetValue(OpenProperty); }
            set { SetValue(OpenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Open.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenProperty =
            DependencyProperty.Register("Open", typeof(double), typeof(DailyStockPricePOCO), new UIPropertyMetadata(0D));

        
        

        public DateTime Date
        {
            get { return (DateTime)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Date.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DateProperty =
            DependencyProperty.Register("Date", typeof(DateTime), typeof(DailyStockPricePOCO), new UIPropertyMetadata(DateTime.MinValue));

        

        public int TICKER
        {
            get { return (int)GetValue(TICKERProperty); }
            set { SetValue(TICKERProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TICKER.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TICKERProperty =
            DependencyProperty.Register("TICKER", typeof(int), typeof(DailyStockPricePOCO), new UIPropertyMetadata(0));



        public string tickerName
        {
            get { return (string)GetValue(tickerNameProperty); }
            set { SetValue(tickerNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for tickerName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty tickerNameProperty =
            DependencyProperty.Register("tickerName", typeof(string), typeof(DailyStockPricePOCO), new UIPropertyMetadata(""));

        


        public int DailyStockPriceID
        {
            get { return (int)GetValue(DailyStockPriceIDProperty); }
            set { SetValue(DailyStockPriceIDProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DailyStockPriceID.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DailyStockPriceIDProperty =
            DependencyProperty.Register("DailyStockPriceID", typeof(int), typeof(DailyStockPricePOCO), new UIPropertyMetadata(0));




        public double Close
        {
            get { return (double)GetValue(CloseProperty); }
            set { SetValue(CloseProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Close.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CloseProperty =
            DependencyProperty.Register("Close", typeof(double), typeof(DailyStockPricePOCO), new UIPropertyMetadata(0D));
        

        

        public double High
        {
            get { return (double)GetValue(HighProperty); }
            set { SetValue(HighProperty, value); }
        }

        // Using a DependencyProperty as the backing store for High.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HighProperty =
            DependencyProperty.Register("High", typeof(double), typeof(DailyStockPricePOCO), new UIPropertyMetadata(0D));




        public double Low
        {
            get { return (double)GetValue(LowProperty); }
            set { SetValue(LowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Low.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LowProperty =
            DependencyProperty.Register("Low", typeof(double), typeof(DailyStockPricePOCO), new UIPropertyMetadata(0D));




        public double Volume
        {
            get { return (double)GetValue(VolumeProperty); }
            set { SetValue(VolumeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Volume.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VolumeProperty =
            DependencyProperty.Register("Volume", typeof(double), typeof(DailyStockPricePOCO), new UIPropertyMetadata(0D));

        
    }
    
    }

