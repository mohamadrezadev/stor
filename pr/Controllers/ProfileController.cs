using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;


namespace pr.Controllers
{

    [Authorize]
    public class ProfileController : Controller
    {
        public IActionResult Index(string showbasket, string masege = null)
        {
            ViewBag.showbasket = showbasket;
            if (!string.IsNullOrEmpty(masege))
            {
                ViewBag.successful = masege;
            }
            return View();
        }
       
    }
}
