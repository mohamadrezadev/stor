using BLL;
using BEE;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pr.Controllers
{
    public class AdminController : Controller
    {

        private readonly IWebHostEnvironment Environment;
        public AdminController(IWebHostEnvironment webHostEnvironment)
        {
            Environment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View("AdminpageIndex");
        }
        public IActionResult creteteacher()
        {
            return View("Techercreate");
        }
        public void create(Models.model.teacher teacher)
        {
            var bltecher = new blteacher();
            var t1 = new teacher();
            t1.name = teacher.name;
            t1.family = teacher.family;
            t1.username = teacher.username;
            t1.password = teacher.pasword;

            uploadfile up = new uploadfile(Environment);
            string namefolder = "teacher";
            t1.image = up.uploadimage(teacher.image, namefolder);
            bltecher.create(t1);
        }
    }
}
