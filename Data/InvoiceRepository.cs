using InvoiceTestApp.Models;
using InvoiceTestApp.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvoiceTestApp.Data
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly DataContex _contex;

        public InvoiceRepository(DataContex contex)
        {
            _contex = contex;
        }
        public void Create(InvoiceVM model)
        {
            Invoice invoice = new Invoice();
            invoice.InvoiceNumber = model.InvoiceNumber;
            invoice.InvoiceDate = DateTime.Now;
            invoice.Rate = model.Rate;
            invoice.StartDate = model.StartDate;
            invoice.EndDate = model.EndDate;
            invoice.Amount = Convert.ToDouble(model.Rate * model.Units);
            invoice.Tax = Convert.ToDouble(invoice.Amount * 0.17);
            invoice.Units = model.Units;
            invoice.Total = Convert.ToDouble(invoice.Tax * invoice.Amount);
            invoice.ChargeId = FindIdForCharge(model.Charge);
            invoice.ClientId = FindIdForClient(model.CompanyName);
            _contex.Add(invoice);
            _contex.SaveChanges();
        }

        public async Task<bool> DeleteInvoice(int invoiceId)
        {
            var invoiceToDelete = await _contex.Invoices.FirstOrDefaultAsync(m => m.Id == invoiceId);
           _contex.Remove(invoiceToDelete);
           
            if (_contex.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<Invoice> GetInvoice(int invoiceId)
        {
            return await _contex.Invoices.AsNoTracking().Include(p => p.Charge).Include(p => p.Client).FirstOrDefaultAsync(m => m.Id == invoiceId);
        }
        public async Task<IEnumerable<Invoice>> GetInvoices()
        {
            return await _contex.Invoices.Include(p => p.Client).Include(p => p.Charge).ToListAsync();
        }
        public bool UpdateInvoice(InvoiceVM model)
        {
            //Mapping properties from VM to Invoice model
            Invoice invoice = new Invoice();
            invoice.Id = model.Id;
            invoice.InvoiceNumber = model.InvoiceNumber;
            invoice.InvoiceDate = model.InvoiceDate;
            invoice.Rate = model.Rate;
            invoice.StartDate = model.StartDate;
            invoice.Units = model.Units;
            invoice.EndDate = model.EndDate;
            invoice.Amount = model.Rate * model.Units;
            invoice.Tax = invoice.Amount * 0.17;
            invoice.Total = invoice.Tax * invoice.Amount;
            invoice.ChargeId = FindIdForCharge(model.Charge);
            invoice.ClientId = FindIdForClient(model.CompanyName);
           

            _contex.Update(invoice);
            int changes = _contex.SaveChanges();
            if ( changes > 0)
            {
                return true;
            }
            return false;
        }
        public int FindIdForCharge(string chargeName)
        {

            Charge chargeFromBase = _contex.Charges.Where(ch => ch.ChargeName.Equals(chargeName)).FirstOrDefault();
            int id = chargeFromBase.Id;
            return id;
        }
        public int FindIdForClient(string companyName)
        {

            Client clientFromBase = _contex.Clients.Where(ch => ch.CompanyName.Equals(companyName)).FirstOrDefault();
            int id = clientFromBase.Id;
            return id;
        }
        //Sav komentarisani kod se odnosi na SP
        //U okviru Migracije je jedna SP koja je neispravna
        /*    public int GetAmountFromProcedure(DateTime dateFrom, DateTime dateTo, int chargeId)
        {
            var sumOut = new SqlParameter
            {
                ParameterName = "AmoutSum",
                SqlDbType = System.Data.SqlDbType.Int,
                Direction = System.Data.ParameterDirection.Output,
            };

            var result = _contex.Database.ExecuteSqlRaw("spGetChargeSumByDateAndCharge {0}, {1}, {2}, {3}", dateFrom, dateTo, chargeId, sumOut);

            return result;
        }*/

    public IEnumerable<Charge> GetCharges()
        {
            return _contex.Charges.ToList();
 
        }
    }
}
