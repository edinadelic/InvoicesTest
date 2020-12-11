using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTestApp.Models
{
    public class Charge
    {
        public int Id { get; set; }
        public string ChargeName { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
