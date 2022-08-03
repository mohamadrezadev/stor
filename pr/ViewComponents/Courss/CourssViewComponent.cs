using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEE;
using BLL;

namespace pr.ViewComponents.Courss
{
    public class CourssViewComponent : ViewComponent
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blcours = new blcours();
            var liscours = blcours.readall_cours();
            return View(liscours);
        }

    }
}
