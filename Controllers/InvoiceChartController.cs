using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceTestApp.Data;
using InvoiceTestApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceTestApp.Controllers
{
    public class InvoiceChartController : Controller
    {
        private readonly IInvoiceRepository _repository;

        public InvoiceChartController(IInvoiceRepository repository)
        {
            _repository = repository;
        }
        // GET: InvoiceChartController1
        public ActionResult Index()
        {
            return View();
        }


        //POST: InvoiceChartController1/Create
        //[HttpPost]
        //public ActionResult GetAmounts(string year, string month)
        //{
        //var yearInt = Convert.ToInt32(year);
        //var monthInt = Convert.ToInt32(month);
        //var lastDayOfMonth = DateTime.DaysInMonth(yearInt, monthInt);
        //var charges = _repository.GetCharges();

        //var beginDate = new DateTime(yearInt, monthInt, 1);
        //var endDate = new DateTime(yearInt, monthInt, lastDayOfMonth);

        //decimal amountDay = 0;
        //decimal amountNight = 0;
        //decimal amountWeekend = 0;

        //foreach (var charge in charges)
        //{
        //    if (charge.ChargeName == "Day")
        //    {
        //        amountDay = _repository.GetAmountFromProcedure(beginDate, endDate, charge.Id);
        //    }

        //    if (charge.ChargeName == "Night")
        //    {
        //        amountNight = _repository.GetAmountFromProcedure(beginDate, endDate, charge.Id);
        //    }

        //    if (charge.ChargeName == "Weekend")
        //    {
        //        amountWeekend = _repository.GetAmountFromProcedure(beginDate, endDate, charge.Id);
        //    }
        //}

        //var model = new GetAmountPerChargeVM();
        //model.AmountDay = amountDay;
        //model.AmountNight = amountNight;
        //model.AmountWeekend = amountWeekend;

        //    return View(model)
        //}
    }   
}
