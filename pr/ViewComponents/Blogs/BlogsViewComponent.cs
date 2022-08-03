using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEE;
using BLL;

namespace pr.ViewComponents.Courss
{
    public class BlogsViewComponent : ViewComponent
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blcours = new blblog();

            var liscours = blcours.readall_blog();
            
            return View(liscours);

           
        }

    }
}
