﻿using DemoProjAppSys.Interface;
using DemoProjAppSys.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProjAppSys.Service
{
    public class ProductCheckOutService: IProductCheckOut
    {
        List<PricingRules> pricingRulesList = new List<PricingRules>();
        Dictionary<string, int> checkoutProductsList = new Dictionary<string, int>();

        public ProductCheckOutService(List<PricingRules> pricingRulesList)
        {
            this.pricingRulesList = pricingRulesList;
        }


        public void Scan(string sku)
        {
            try
            {
                if (pricingRulesList.Any(prod => prod.sku == sku))
                {
                    if (checkoutProductsList.ContainsKey(sku))
                    {
                        checkoutProductsList[sku] = checkoutProductsList[sku] + 1;
                    }
                    else
                    {
                        checkoutProductsList.Add(sku, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void TotalPayAmount()
        {
            try
            {
                double total = 0;

                if (checkoutProductsList.ContainsKey("vga"))
                {
                    total = total + pricingRulesList.Find(x => x.sku == "vga").price;
                }

                foreach (var rules in pricingRulesList)
                {
                    if (rules.sku != null && checkoutProductsList.ContainsKey(rules.sku))
                    {
                        if (rules.sku == "atv" && checkoutProductsList.ContainsKey(rules.sku))
                        {
                            if (checkoutProductsList[rules.sku] % rules.offer.offerQuantity == 0)
                            {
                                total = total + (checkoutProductsList[rules.sku] / rules.offer.offerQuantity) *
                                2 * rules.price;
                            }
                            else
                            {
                                total = total + (checkoutProductsList[rules.sku] * rules.price);
                            }
                        }

                        if (rules.sku == "ipd" && checkoutProductsList.ContainsKey("ipd"))
                        {
                            if (checkoutProductsList[rules.sku] > rules.offer.offerQuantity)
                            {
                                total = total + (checkoutProductsList[rules.sku] * 499.99);
                            }
                            else
                            {
                                total = total + (checkoutProductsList[rules.sku] * rules.price);
                            }

                        }

                        if (rules.sku == "mbp" && checkoutProductsList.ContainsKey("mbp"))
                        {
                            if (checkoutProductsList[rules.sku] > 0)
                            {
                                total = total + (checkoutProductsList[rules.sku] * rules.price);
                                if (checkoutProductsList.ContainsKey("vga"))
                                {
                                    checkoutProductsList["vga"] = checkoutProductsList["vga"] + checkoutProductsList[rules.sku];
                                }
                                else
                                {
                                    checkoutProductsList.Add("vga", checkoutProductsList[rules.sku]);
                                }
                            }
                            else
                            {
                                total = total + (checkoutProductsList[rules.sku] * rules.price);
                            }
                        }
                    }
                }

                foreach (var product in checkoutProductsList)
                {
                    Console.WriteLine(product.Key + " ==> " + product.Value);
                }
                Console.WriteLine("Amount to be paid => " + total);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
