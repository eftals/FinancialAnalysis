using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using FinanceAnalysis.POCO;
using System.Windows;



namespace FinanceAnalysis
{
    class YahooStockService
    {
        System.Timers.Timer stockTimer = new System.Timers.Timer();
   
        private string yhooHist;
        private string yhooLastPrice;
        private List<TickerPOCO> subscribed = new List<TickerPOCO>();

        private volatile object lockObj = new object();


        public void clearsubscriptions()
        {
            stockTimer.Enabled = false;
            lock (lockObj)
            {
                Application.Current.Dispatcher.BeginInvoke((Action)delegate()
                {
                    try
                    {
                        if (subscribed != null) subscribed.Clear();
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine(exp);
                    }
                });
                
            }
            stockTimer.Enabled = true;
        }


        public bool subscribe(TickerPOCO newVal)
        {
            lock (lockObj)
            {
                Application.Current.Dispatcher.BeginInvoke((Action)delegate()
                {
                    try
                    {
                        subscribed.Add(newVal);
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine(exp);
                    }
                });
                
                
            }
            return true;
        }

        public void getLatestPrices(object source, System.Timers.ElapsedEventArgs e)
        {
            lock (lockObj)
            {
                foreach (TickerPOCO tkr in subscribed)
                {
                    try
                    {
                        String[] str = Regex.Split(yhooLastPrice, "{TICKER}");

                        StringBuilder webRequest = new StringBuilder(str[0]);
                        webRequest.Append(tkr.TickerName);
                        webRequest.Append(str[1]);

                        string responseFromServer = processWebRequest(webRequest.ToString());


                        var serviceResult = responseFromServer.Split(',');

                        if (serviceResult.Length != 3) return;

                        Application.Current.Dispatcher.
                            BeginInvoke((Action)delegate()
                        {
                            try
                            {
                                //Console.WriteLine("spinning on " + serviceResult);

                                tkr.Date = DateTime.Parse(serviceResult[0].Split('\"')[1] + " " + serviceResult[1].Split('\"')[1]);
                                tkr.LastPrice = double.Parse(serviceResult[2]);
                                tkr.LastUpdated = DateTime.Now;
                            }
                            catch (Exception exp)
                            {
                                Console.WriteLine(exp);
                            }
                        });
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine(exp);
                    }
                }
            }
        }

        public YahooStockService(string HistoryRequest, string LastPriceRequest)
        {
            yhooHist = HistoryRequest;
            yhooLastPrice = LastPriceRequest;
         
            
            stockTimer.Elapsed += new System.Timers.ElapsedEventHandler(getLatestPrices);
            stockTimer.Interval = 5000;
            stockTimer.Enabled = true;
      
        }

        private YahooStockService()
        {
        }

        private string processWebRequest(string urlString)
        {
            WebRequest request = WebRequest.Create(urlString);

            WebResponse response = request.GetResponse();

            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            //Console.WriteLine(responseFromServer);
            // Clean up the streams and the response.

            reader.Close();
            response.Close();
            return responseFromServer;
        }

        public void getStockHistory(string tkr)
        {
            try
            {
                String[] str = Regex.Split(yhooHist, "{TICKER}");

                StringBuilder webRequest = new StringBuilder(str[0]);
                webRequest.Append(tkr);
                webRequest.Append(str[1]);

                string responseFromServer = processWebRequest(webRequest.ToString());

                var Sequence = responseFromServer.Split('\n').Skip(1).SkipWhile(checkNull => checkNull.Length < 10)
                .Select(s => s.Split(',')).Select(a => new DailyStockPrice
                {
                    Date = DateTime.Parse(a[0].ToString()),
                    Open = double.Parse(a[1].ToString()),
                    High = double.Parse(a[2].ToString()),
                    Low = double.Parse(a[3].ToString()),
                    Close = double.Parse(a[4].ToString()),
                    Volume = Int32.Parse(a[5].ToString()),
                    adjClose = double.Parse(a[6].ToString())
                });


                using (EftalEntities1 objCtx = new EftalEntities1())
                {
                    var stockRecord = (from cs in objCtx.Tickers
                                       where cs.TickerName == tkr
                                       select cs).FirstOrDefault();


                    var priceHist = objCtx.DailyStockPrices.Where(a => a.TICKER == stockRecord.TickerID);

                    foreach (DailyStockPrice item in priceHist)
                        objCtx.DailyStockPrices.DeleteObject(item);

                    objCtx.SaveChanges();
                
                    Int32 maxID;
                    if (objCtx.DailyStockPrices.FirstOrDefault() == null)
                    {
                        maxID = 0;
                    }
                    else
                     maxID = objCtx.DailyStockPrices.Max(a => a.DailyStockPriceID);
             
                    
                    
                    foreach (var s in Sequence)
                    {
                        maxID++;
                        s.TICKER = stockRecord.TickerID;
                        s.DailyStockPriceID = maxID;
                        objCtx.AddToDailyStockPrices(s);

                        objCtx.SaveChanges();
                    }
                  
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Cought exception. " + e.Message);
            }

        }



       
    }
}
