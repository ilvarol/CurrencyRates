using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Business
{
    public class TCMBCurrencyRate
    {
        public string Date { get; set; } = default!;
        public string CrossOrder { get; set; } = default!;
        public string Kod { get; set; } = default!;
        public string CurrencyCode { get; set; } = default!;
        public string Unit { get; set; } = default!;
        public string Isim { get; set; } = default!;
        public string CurrencyName { get; set; } = default!;
        public string ForexBuying { get; set; } = default!;
        public string ForexSelling { get; set; } = default!;
        public string BanknoteBuying { get; set; } = default!;
        public string BanknoteSelling { get; set; } = default!;
        public string CrossRateUSD { get; set; } = default!;
        public string CrossRateOther { get; set; } = default!;
    }
}
