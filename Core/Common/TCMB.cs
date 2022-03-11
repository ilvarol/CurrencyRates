using Core.Models.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Core.Common
{
    public class TCMB
    {
        public List<TCMBCurrencyRate> FetchCurrencyRatesFromTCMB()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("http://www.tcmb.gov.tr/kurlar/today.xml");

            var dateNode = xml.SelectSingleNode("//Tarih_Date");
            var currencyNode = dateNode!.SelectNodes("//Currency");
            int totalCurrencyNode = currencyNode!.Count;

            var dovizler = new List<TCMBCurrencyRate>();

            for (int i = 0; i < totalCurrencyNode; i++)
            {
                var current = currencyNode[i]!;

                dovizler.Add(new TCMBCurrencyRate
                {
                    CrossOrder = current.Attributes!["CrossOrder"]!.Value.Trim(),
                    Kod = current.Attributes["Kod"]!.Value.Trim(),
                    CurrencyCode = current.Attributes["CurrencyCode"]!.Value!.Trim(),
                    Unit = current["Unit"]!.InnerXml.Trim(),
                    Isim = current["Isim"]!.InnerXml.Trim(),
                    CurrencyName = current["CurrencyName"]!.InnerXml.Trim(),
                    ForexBuying = current["ForexBuying"]!.InnerXml.Trim(),
                    ForexSelling = current["ForexSelling"]!.InnerXml.Trim(),
                    BanknoteBuying = current["BanknoteBuying"]!.InnerXml.Trim(),
                    BanknoteSelling = current["BanknoteSelling"]!.InnerXml.Trim(),
                    CrossRateUSD = current["CrossRateUSD"]!.InnerXml.Trim(),
                    CrossRateOther = current["CrossRateOther"]!.InnerXml.Trim()
                });
            }

            return dovizler;
        }
    }
}
