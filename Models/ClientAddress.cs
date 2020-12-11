using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTestApp.Models
{
    public class ClientAddress
    {
        public int Id { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public virtual Client Client { get; set; }
    }
}
