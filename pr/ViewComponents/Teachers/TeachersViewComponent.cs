using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEE;
using BLL;
namespace pr.ViewComponents.Courss.Teacher
{
    public class TeachersViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blt = new blteacher();
            var listtecher = blt.readall_teacher();
            return View( listtecher);
        }
    }
}
