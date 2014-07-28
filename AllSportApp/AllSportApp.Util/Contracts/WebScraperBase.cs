using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSportApp.Util.Contracts
{
    public abstract class WebScraperBase
    {
        protected string Url { get; set; }

        public abstract string ScrapeWeb();

        public virtual WebScraperBase SetUrl(string url)
        {
            this.Url = url;
            return this;
        }
    }
}
