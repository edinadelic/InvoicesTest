using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTestApp.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public int InvoiceNumber { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Rate { get; set; }
        public double Units { get; set; }
        public double Tax { get; set; }
        public double Amount { get; set; }
        public double Total { get; set; }
        public int ChargeId { get; set; }
        public virtual Charge Charge { get; set; }
    }
}
