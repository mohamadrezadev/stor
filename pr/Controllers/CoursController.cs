using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEE;
using BLL;
namespace pr.Controllers
{
    public class CoursController : Controller
    {
        private readonly IWebHostEnvironment Environment;
        public CoursController(IWebHostEnvironment webHostEnvironment)
        {
            Environment = webHostEnvironment;
        }
        [Route("Cours")]
        public IActionResult Index()
        {
            var blc = new blcours();
            return View("page_procouct",blc.readall_cours());

        }
        public IActionResult get_skip(int c)
        {
            var blc = new blcours();
            return RedirectToAction(nameof(Index), blc.readall_cours());
            
        }
        public IActionResult cors()
        {
            blteacher blt = new blteacher();
            List<teacher> techers = blt.readall_teacher();
            List<teacher> tt = new List<teacher>();
            foreach (var item in techers)
            {
                if (item.name != null & item.family != null && item.id != 0)
                {
                    tt.Add(item);
                }
            }
            ViewBag.teacher = tt;


            return View("createcours");
        }
        [Route("cours/Addcours")]
        public IActionResult createcours(Models.model.cours cours)
        {
            if (cours != null)
            {
                var blcours = new blcours();
                var bltecher = new blteacher();
                var cours1 = new cours();
                cours1.titel = cours.titel;
                cours1.details = cours.details;
                cours1.time = cours.time;
                cours1.price = cours.price;


                uploadfile up = new uploadfile(Environment);
                string namefolder = "cours";
                cours1.image = up.uploadimage(cours.image, namefolder);
                var namefoldervideo = "cours";
                cours1.video = up.uploadvideo(cours.video, namefoldervideo);

                if (cours.idtechers != null)
                {
                    foreach (var item in cours.idtechers)
                    {
                        if (item != 0)
                        {
                            var teacher = bltecher.serchbynid(Convert.ToInt32(item));

                            cours1.Courss_techers = new List<techer_Cours>();
                            cours1.Courss_techers.Add(new techer_Cours { teacherId = teacher.id, courseId = item });

                        }
                    }
                }
                blcours.create(cours1);
                return RedirectToAction(nameof(getall));
            }
            else
            {
                return null;
            }
        }
        [Route("cours/all")]
        public IActionResult getall()
        {
            var blc = new blcours();
            var list = blc.readall_cours();


            ViewBag.courss = list;
            return View();
        }
        public IActionResult searching(string s)


        {
            var blc = new blcours();
            List<BEE.cours> list = blc.serch(s);
            ViewBag.courss = list;
            return View("getall");
        }
        public Models.model.cours modelcours = new Models.model.cours();
        public IActionResult Edit(int id)
        {

            var blc = new blcours();
            var cours1 = blc.serchbynid(id);



            blteacher blt = new blteacher();
            List<teacher> techers = blt.readall_teacher();
            if (cours1 != null)
            {
                modelcours.id = cours1.id;
                modelcours.details = cours1.details;
                modelcours.time = cours1.time;
                modelcours.price = cours1.price;
                modelcours.videourl = cours1.video;
                modelcours.imagurl = cours1.image;
                modelcours.titel = cours1.titel;
                modelcours.idtechers = cours1.Courss_techers.Select(s => s.Teachers.id).ToList();

            }

            ViewBag.teacher = techers;
            return View(modelcours);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editt(Models.model.cours cours1)
        {

            var blcours = new blcours();
            var becours = new cours();
            var bltecher = new blteacher();
            var beecours = blcours.serchbynid(cours1.id);

            becours.id = cours1.id;
            becours.titel = cours1.titel;
            becours.time = cours1.time;
            becours.price = cours1.price;
            becours.details = cours1.details;

            uploadfile up = new uploadfile(Environment);

            if (cours1.video != null)
            {

                var namefoldervideo = "cours";
                becours.video = up.uploadvideo(cours1.video, namefoldervideo);
            }
            else if (cours1.image != null)
            {
                string namefolder = "cours";
                becours.image = up.uploadimage(cours1.image, namefolder);
            }
            if (cours1.idtechers != null)
            {
                foreach (var item in cours1.idtechers)
                {
                    if (item != 0)
                    {
                        var teacher = bltecher.serchbynid(Convert.ToInt32(item));

                        becours.Courss_techers = new List<techer_Cours>();
                        becours.Courss_techers.Add(new techer_Cours { teacherId = teacher.id, courseId = item });

                    }
                }
            }
            
            blcours.update(becours);
            return RedirectToAction(nameof(getall));
        }
        [Route("Cours/Delet/{id?}")]
        public IActionResult Delet(int id)
        {
            var blc = new blcours();
            var cours1 = blc.serchbynid(id);
            if (cours1 != null)
            {
                blc.delet(id);
            }
            return RedirectToAction(nameof(getall));
        }

        public IActionResult searchCours(int id)
        {
            var blc = new blcours();
            var cours1 = blc.serchbynid(id);
            return View("coursessuser", cours1);
        }
    }
}
