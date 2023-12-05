using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEData.Scrapper.Entities
{
    public class Company:IEntity<int>
    {
        public int id { get; set; }
        public string StockCodeName { get; set; }

        public IList<Price> priceList { get; set; }
    }
}
