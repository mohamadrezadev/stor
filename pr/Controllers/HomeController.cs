using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pr.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ZarinpalSandbox;

namespace pr.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult contentus()
        {
            return View("contentus");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult OnlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"].ToString();
                var blorder = new blorder();
                var o= blorder.serchbyid(id);
               
                var payment = new Payment(o.totalpric);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    if (HttpContext.Session.GetString("basket") != null)
                    {
                        HttpContext.Session.Clear();
                    }
                    o.statustpayment = true;
                    blorder.update(o);
                    
                    ViewBag.code = res.RefId;
                    return View("Verify");
                }

            }

            return NotFound();
        }
    }
}
