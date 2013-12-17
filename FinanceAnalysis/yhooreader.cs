using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;

namespace FinanceAnalysis
{
    class yhooreader
    {
   
        private string yhooRequest;

        public yhooreader(string request)
        {
            yhooRequest = request;    
        }

        private yhooreader()
        {
        }

        public List<object> getStockHistory(string tkr)
        {
            try
            {
                String[] str = Regex.Split(yhooRequest, "{TICKER}");

                StringBuilder webRequest = new StringBuilder(str[0]);
                webRequest.Append(tkr);
                webRequest.Append(str[1]);



                WebRequest request = WebRequest.Create(webRequest.ToString());

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


                    var maxID = objCtx.DailyStockPrices.Max(a => a.TICKER);
             
                    
                    
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


            
            return null;

        }



       
    }
}
