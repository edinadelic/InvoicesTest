using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTestApp.ViewModels
{
    public class GetAmountPerChargeVM
    {
        public decimal AmountDay { get; set; }
        public decimal AmountNight { get; set; }
        public decimal AmountWeekend { get; set; }
    }

}
