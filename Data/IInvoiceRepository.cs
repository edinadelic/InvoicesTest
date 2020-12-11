using InvoiceTestApp.Models;
using InvoiceTestApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTestApp.Data
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetInvoices();
        void Create(InvoiceVM model);
        Task<Invoice> GetInvoice(int invoiceId);
        Task<bool> DeleteInvoice(int invoiceId);
        bool UpdateInvoice(InvoiceVM model);
        int FindIdForCharge(string chargeName);
        int FindIdForClient(string companyName);
        //int GetAmountFromProcedure(DateTime dateFrom, DateTime dateTo, int chargeId);
        IEnumerable<Charge> GetCharges();
    }
}
