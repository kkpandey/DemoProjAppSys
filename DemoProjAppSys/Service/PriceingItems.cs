using DemoProjAppSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProjAppSys.Service
{
    public class PriceingItems
    {
        public List<PricingRules> GetPricingRules()
        {
            List<PricingRules> pricingRulesObj = new List<PricingRules>
    {
        new PricingRules() {
            sku = "atv",
            name = "Apple TV",
            price=109.50,
            offer=GetOffer().Where(x=>x.offerQuantity==3).FirstOrDefault()
            },
        new PricingRules() {
            sku = "ipd",
            name = "Super iPad",
            price=549.99,
            offer=GetOffer().Where(x=>x.offerQuantity==4).FirstOrDefault()
            },
        new PricingRules() {
            sku = "mbp",
            name = "MacBook Pro",
            price=1399.99,
            offer=GetOffer().Where(x=>x.offerQuantity==1).FirstOrDefault()
            },
        new PricingRules() {
            sku = "vga",
            name = "VGA adapter",
            price=30.00,
            offer=GetOffer().Where(x=>x.offerQuantity==0).FirstOrDefault()
            }
    };
            return pricingRulesObj;
        }
        public List<Offer> GetOffer()
        {
            List<Offer> offer = new List<Offer>
    {
        new Offer() {offerQuantity = 3,offerDeal = "Buy 3 Apple TVs, pay the price of 2 only"},
        new Offer() {offerQuantity = 4,offerDeal = "Buy 4 iPad, price will drop to $499.99 each"},
        new Offer() {offerQuantity = 1,offerDeal = "Buy 1 MacBook Pro, get free VGA adapter free"},
        new Offer() {offerQuantity = 0,offerDeal = ""},

    };
            return offer;
        }
       
    }
}
