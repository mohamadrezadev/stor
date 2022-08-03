using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pr
{
    public class uploadfile
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public uploadfile(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public string uploadimage(IFormFile File, string namefolder)
        {
            if (File == null) return "";
            var path = _webHostEnvironment.WebRootPath + "\\iamges1\\" + namefolder + "\\" + File.FileName;
            using var f = System.IO.File.Create(path);
            File.CopyTo(f);
            return File.FileName;



        }
        public string uploadvideo(IFormFile File, string namefolder)
        {
            if (File == null) return "";
            var path = _webHostEnvironment.WebRootPath + "\\videos\\" + namefolder + "\\" + File.FileName;
            using var f = System.IO.File.Create(path);
            File.CopyTo(f);
            path = path.Split("wwwroot")[1];
            return File.FileName;



        }
    }
}
