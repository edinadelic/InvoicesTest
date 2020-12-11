using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using InvoiceTestApp.Data;
using InvoiceTestApp.Models;
using InvoiceTestApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceTestApp.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository _repository;
        private readonly IMapper _mapper;

        public InvoiceController(IInvoiceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET: InvoiceController
        public async Task<ActionResult> Index(string sortOrder, string searchString, DateTime? fromDate, DateTime? toDate)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["FilterByCompany"] = searchString;

            var invoicesFromRepo = await _repository.GetInvoices();
            var invoices = _mapper.Map<IEnumerable<InvoiceVM>>(invoicesFromRepo);

            if (!String.IsNullOrEmpty(searchString))
            {
                invoices = invoices.Where(s => s.CompanyName.ToLower().Contains(searchString.ToLower())
                                       || s.CompanyName.ToLower().Contains(searchString.ToLower()));
            }

            if (fromDate != null && toDate != null)
            {
                invoices = invoices.Where(id => id.InvoiceDate >= fromDate && id.InvoiceDate <= toDate);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    invoices = invoices.OrderByDescending(i => i.CompanyName);
                    break;
                case "Date":
                    invoices = invoices.OrderBy(i => i.InvoiceDate);
                    break;
                case "date_desc":
                    invoices = invoices.OrderByDescending(i => i.InvoiceDate);
                    break;
                default:
                    invoices = invoices.OrderBy(s => s.CompanyName);
                    break;
            }
            return View(invoices);
        }

        // GET: InvoiceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InvoiceController/Create
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            Invoice invoiceFromRepo;
            InvoiceVM model = new InvoiceVM();
   
            if (id == 0)
                return View(new InvoiceVM());
            else
            {
                invoiceFromRepo = await _repository.GetInvoice(id);
                model = _mapper.Map<InvoiceVM>(invoiceFromRepo);

            }
                return View(model);
        }


        // POST: InvoiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddOrEdit([Bind("Id,InvoiceNumber,InvoiceDate,StartDate,EndDate,Rate,Units,Tax,Amount,Charge,CompanyName")] InvoiceVM model)
        {
            if (ModelState.IsValid)
            {
                if(model.Id == 0)
                {

                    try
                    {
                        _repository.Create(model);
                        return RedirectToAction("Index");
                    }
                    catch (Exception err)
                    {

                        throw new Exception(err.Message);
                    }
                }
                else
                {
                    var invoiceFromRepo = _repository.GetInvoice(model.Id);

                    if (_repository.UpdateInvoice(model))
                    {
                        return RedirectToAction("Index");
                    }
                    
                    ModelState.AddModelError("", "Update failed");
                }
            }
            return View();

        }

        // GET: InvoiceController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var changes = await _repository.DeleteInvoice(id);
            if (changes)
            {
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
        } 

        // POST: InvoiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
