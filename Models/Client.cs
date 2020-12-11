using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTestApp.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string ContactPerson { get; set; }
        public int? AddressId { get; set; }
        public ClientAddress ClientAddress { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
