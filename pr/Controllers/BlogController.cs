using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BEE;
using BLL;
using Microsoft.AspNetCore.Hosting;

namespace pr.Controllers
{
    public class BlogController : Controller
    {
        private readonly IWebHostEnvironment Environment;
        public BlogController(IWebHostEnvironment webHostEnvironment)
        {
            Environment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var blg = new blblog();
            return View("Blog", blg.readall_blog());
            
        }
        public IActionResult get_skip(int c)
        {
            var blg = new blblog();
            return RedirectToAction(nameof(Index), blg.readall_blog());

        }
        public async Task<IActionResult> readall()
        {
            var bl = new blblog();
            ViewBag.blogs = bl.readall_blog();
            return View("readallblogs");

        }
        public async Task<IActionResult> edit(Models.model.blog b)
        {
            var blog = new blog();
            blog.id = b.id;
            blog.titel = b.titel;
            blog.text2 = b.text2;
            blog.text3 = b.text3;
            blog.text4 = b.text4;
            blog.foter = b.foter;


           uploadfile up = new uploadfile(Environment);
            if (b.image!=null)
            {
                blog.image=up.uploadimage(b.image,"blog");
            }
            return RedirectToAction(nameof(readall));
        }
        public IActionResult delet(int id)
        {
            var blb = new blblog();
            blb.delet(id);
            return RedirectToAction(nameof(readall));
        }
        public IActionResult searchbyid(int id)
        {
            var blb = new blblog();
            var b = blb.serchbynid(id);
            Models.model.blog blog_new = new Models.model.blog();
            blog_new.titel = b.titel;
            blog_new.text1 = b.text1;
            blog_new.text2 = b.text2;
            blog_new.text3 = b.text3;
            blog_new.text4 = b.text4;
            blog_new.intro = b.intro;
            blog_new.videourl = b.video;
            blog_new.imagurl = b.image;

            return View("blogedit",blog_new);
        }
        public IActionResult create()
        {
            return View("Blog");
        }
        [HttpPost]
        public IActionResult create(Models.model.blog blog)
        {
            var blblog = new blblog();
            var new_bloge = new blog();
            new_bloge.titel = blog.titel;
            new_bloge.intro = blog.intro;
            new_bloge.text1 = blog.text1;
            new_bloge.text2 = blog.text2;
            new_bloge.text3 = blog.text3;
            new_bloge.text4 = blog.text4;
            new_bloge.foter = blog.foter;

            uploadfile up = new uploadfile(Environment);
            new_bloge.image = up.uploadimage(blog.image, "blog");
            new_bloge.video = up.uploadimage(blog.video, "blog");

            blblog.create(new_bloge);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> readall_forclient()
        {
            var bl = new blblog();
            var listblogs = bl.readall_blog();
            return View("blogforclient",listblogs);

        }
        public async Task<IActionResult> searchbyid_client(int id)
        {
            var blb = new blblog();
            return View("blogsearch", blb.serchbynid(id));
        }
    }
}
