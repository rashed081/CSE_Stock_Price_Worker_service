using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSEData.Scrapper.Entities
{
    public class Price:IEntity<Guid>
    {
        public Guid id { get; set; }
        public int companyId { get; set; }
        public double LTP { get; set; }
        public double open { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public int volume { get; set; }
        public DateTime time { get; set; }

        
    }
}
