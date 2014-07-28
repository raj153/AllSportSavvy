using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AllSportApp.Util.Contracts;
using AllSportApp.Util.Concrete;
namespace AllSportApp.TestConsole
{
    public class ScraperTest
    {
        static void Main(string[] args)
        {
            string url = "http://www.espncricinfo.com/ci/content/match/fixtures/calendar.html";
            WebScraperBase wsb = new EspnWebScraper();
            wsb.SetUrl(url).ScrapeWeb();
        }
    }
}
