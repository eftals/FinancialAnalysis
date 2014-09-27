using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;

namespace FinanceAnalysis.POCO
{
    class TickerPOCO : DependencyObject, INotifyPropertyChanged
    {


        public int TickerID
        {
            get { return (int)GetValue(TickerIDProperty); }
            set { SetValue(TickerIDProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TickerID.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TickerIDProperty =
            DependencyProperty.Register("TickerID", typeof(int), typeof(TickerPOCO), new UIPropertyMetadata(0));




        /*public string TickerName
        {
            get { return (string)GetValue(TickerNameProperty); }
            set {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Ticker name is mandatory.");
                }
                SetValue(TickerNameProperty, value); 
            }
        }

        // Using a DependencyProperty as the backing store for TickerName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TickerNameProperty =
            DependencyProperty.Register("TickerName", typeof(string), typeof(TickerPOCO), new UIPropertyMetadata(""));*/



        public double LastPrice
        {
            get { return (double)GetValue(LastPriceProperty); }
            set { SetValue(LastPriceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LastPrice.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastPriceProperty =
            DependencyProperty.Register("LastPrice", typeof(double), typeof(TickerPOCO), new UIPropertyMetadata(0d));



        public int Volume
        {
            get { return (int)GetValue(VolumeProperty); }
            set { SetValue(VolumeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Volume.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VolumeProperty =
            DependencyProperty.Register("Volume", typeof(int), typeof(TickerPOCO), new UIPropertyMetadata(0));



        public DateTime Date
        {
            get { return (DateTime)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Date.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DateProperty =
            DependencyProperty.Register("Date", typeof(DateTime), typeof(TickerPOCO), new UIPropertyMetadata(DateTime.MinValue));




        public DateTime LastUpdated
        {
            get { return (DateTime)GetValue(LastUpdatedProperty); }
            set { SetValue(LastUpdatedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LastUpdated.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LastUpdatedProperty =
            DependencyProperty.Register("LastUpdated", typeof(DateTime), typeof(TickerPOCO), new UIPropertyMetadata(DateTime.MinValue));




        public string Email
        {
            get { return (string)GetValue(EmailProperty); }
            set { SetValue(EmailProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Email.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EmailProperty =
            DependencyProperty.Register("Email", typeof(string), typeof(TickerPOCO), new PropertyMetadata(""));

        

        string _tickerName;
        public string TickerName
        {
            get
            {
                return _tickerName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("Ticker name is mandatory.");
                }
                if (_tickerName != value)
                {
                    _tickerName = value;
                    RaisePropertyChanged("TickerName");
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
