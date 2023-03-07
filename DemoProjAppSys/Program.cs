using DemoProjAppSys.Model;
using DemoProjAppSys.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProjAppSys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<PricingRules> pricingRulesList = new List<PricingRules>();
            PriceingItems priceingItems = new PriceingItems();
            pricingRulesList = priceingItems.GetPricingRules();
            ProductCheckOutService storeCheckoutObj = new ProductCheckOutService(pricingRulesList);

            storeCheckoutObj.Scan("ipd");
            storeCheckoutObj.Scan("ipd");
            storeCheckoutObj.Scan("ipd");
            storeCheckoutObj.Scan("ipd");
            storeCheckoutObj.Scan("ipd");
            //Bye 3 Apple Tv 
            storeCheckoutObj.Scan("atv");
            storeCheckoutObj.Scan("atv");
            storeCheckoutObj.Scan("atv");
                             
            storeCheckoutObj.Scan("mbp");
            storeCheckoutObj.Scan("mbp");
            //Amount Payed to users
            storeCheckoutObj.TotalPayAmount();
        }
    }
}
