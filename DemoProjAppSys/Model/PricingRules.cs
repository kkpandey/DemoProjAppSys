using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProjAppSys.Model
{
    public class PricingRules
    {
        public string sku { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public Offer offer { get; set; }

    }
    public class Offer
    {
        public int offerQuantity { get; set; }
        public string offerDeal { get; set; }
    }
}
