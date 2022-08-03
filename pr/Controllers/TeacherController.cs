using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using BEE;
using Microsoft.AspNetCore.Routing;

namespace pr.Controllers
{
    public class TeacherController : Controller
    {
        private readonly IWebHostEnvironment Environment;
        public TeacherController(IWebHostEnvironment webHostEnvironment)
        {
            Environment = webHostEnvironment;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [Route("Teacher/creteteacher")]
        public IActionResult creteteacher()
        {
            return View("Techercreate");
        }
        
        [HttpPost]
        public IActionResult create(Models.model.teacher teacher)
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
            return RedirectToAction(nameof(read));
        }
        [Route("teachers/all")]
        public IActionResult read()
        {
            var bltecher = new blteacher();

            return View("datatecher", bltecher.readall_teacher());
        }
        [Route("teachers/edit")]
        public async Task<IActionResult> update_data(Models.model.teacher teacher, int id)
        {
            var bltecher = new blteacher();
            var t1 = new teacher();
            t1.id = teacher.id;
            t1.name = teacher.name;
            t1.family = teacher.family;
            t1.email = teacher.email;
            t1.username = teacher.username;
            t1.password = teacher.pasword;
            if (teacher.image!=null)
            {
                uploadfile up = new uploadfile(Environment);
                string namefolder = "teacher";
                t1.image = up.uploadimage(teacher.image, namefolder);

            }
            bltecher.edit(id, t1);
            return RedirectToAction(nameof(read));

        }
        [Route("Delet teacher")]
        public IActionResult delet(int id)
        {
            var bltecher = new blteacher();
            bltecher.delet(id);
            return RedirectToAction(nameof(read));
        }
    }
}
