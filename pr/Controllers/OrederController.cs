using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using static pr.Models.model;

namespace pr.Controllers
{
    [Authorize]
    public class OrederController : Controller
    {
        [Route("Addtobasket")]
        public async Task<IActionResult> Addtobasket(int idcours)
        {
            var listbasket = new List<int>();
            if (HttpContext.Session.GetString("basket")!=null)
            {
               listbasket= JsonConvert.DeserializeObject<List<int>>(HttpContext.Session.GetString("basket")).ToList();

            }

            listbasket.Add(idcours);

            HttpContext.Session.SetString("basket", JsonConvert.SerializeObject(listbasket));
            return RedirectToAction("searchCours", "Cours",new { id =idcours});
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
