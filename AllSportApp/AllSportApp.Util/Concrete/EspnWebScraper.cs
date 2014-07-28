using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllSportApp.Util.Contracts;
using AllSportApp.Domain;
using HtmlAgilityPack;
using System.IO;
namespace AllSportApp.Util.Concrete
{
    public class EspnWebScraper : WebScraperBase
    {
        public override string ScrapeWeb()
        {
            var hWeb = new HtmlWeb();
            var hDoc = hWeb.Load(this.Url);
            var coltData = new Collection<EventDetail>();
            var sbData = new StringBuilder();
            
            var sportNodes = (hDoc.DocumentNode.SelectNodes("//div[@class='cal']//tr[td[@class='head' or 'item']]"));
            var arrMonth = new string[]{"january", "february","march","april","may","june","july","august","september","october","november","december"};
            //td[@class='head' or 'item']
            using(StreamWriter sw = new StreamWriter("EspanSportData.txt"))
            {
                string year ="",month = "";
                //bool b
                foreach (var sNode in sportNodes)
                {
                    if (sNode.ChildNodes.Count == 1 && sNode.ChildNodes[0].InnerText!="Top")
                    {
                        var arrCal = sNode.ChildNodes[0].ChildNodes[1].InnerText.Split(' ');
                        year = arrCal[1];
                        month = arrCal[0];
                          
                    }
                    else
                    {
                        if(sNode.ChildNodes[0].InnerText =="Top" || string.IsNullOrEmpty(sNode.ChildNodes[1].InnerText)) continue;
                        //var tdNodes 
                        
                        var tdDayCol = sNode.ChildNodes[0].InnerText.Split(' ')[0];
                        var h5Nodes = sNode.ChildNodes[1].SelectNodes("h5");
                        foreach (var h5Node in h5Nodes)
                        {
                            var tdEventName = h5Node.InnerText;
                            var tdAddDetail = h5Node.NextSibling.InnerText;
                            var dateTime = new DateTime(Int32.Parse(year), Array.IndexOf(arrMonth, month.ToLower()) + 1, Int32.Parse(tdDayCol));

                            sw.WriteLine("new Event | Date = DateTime.Parse(\"{0}\"),\tName = \"{1}\",\t AddDetails = \"{2}\" #,", dateTime.AddHours(10), tdEventName, tdAddDetail);    
                        }
                        

                    }
                
                }
            }
            return sbData.ToString();
        }
        
    }
}
