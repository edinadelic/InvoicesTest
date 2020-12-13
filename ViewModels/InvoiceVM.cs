using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTestApp.ViewModels
{
    public class InvoiceVM
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Invoice Number")]
        public int InvoiceNumber { get; set; }
        [Display(Name = "Company Name")]
        [Required]
        public string CompanyName { get; set; }

        [Display(Name = "Invoice Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime InvoiceDate { get; set; }

        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]
        public double Units { get; set; }
     
        public double Amount { get; set; }
        public double Total { get; set; }
        [Required]
        public string Charge { get; set; }
    }
}
