using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pr.Models
{
    public class model
    {
        public class cours
        {
            public int id { get; set; }
            public string titel { get; set; }
            public IFormFile image { get; set; }
            public IFormFile video { get; set; }
            public float price { get; set; }
            public int time { get; set; }
            public string details { get; set; }
            public string videourl { get; set; }
            public string imagurl { get; set; }
            public List<int> idtechers { get; set; }
        }

        public class teacher
        {
            public int id { get; set; }
            public string name { get; set; }
            public string family { get; set; }
            public string username { get; set; }
            public string pasword { get; set; }
            public string email { get; set; }
            public IFormFile image { get; set; }
            public string interdus_video { get; set; }

            public List<cours> list_cours { get; set; }

        }
        public class user
        {
            public int id { get; set; }
            public string name { get; set; }
            public string family { get; set; }
            public string username { get; set; }
            public string password { get; set; }
            public string passwordconfirm { get; set; }
            public string email { get; set; }
            public IFormFile pic { get; set; }



        }
        public class blog
        {
            public int id { get; set; }
            public IFormFile image { get; set; }
            public IFormFile video { get; set; }
            public string videourl { get; set; }
            public string imagurl { get; set; }
            public string titel { get; set; }
            public string intro { get; set; }
            public string text1 { get; set; }
            public string text2 { get; set; }
            public string text3 { get; set; }
            public string text4 { get; set; }
            public string foter { get; set; }
        }
        public class cours_deteilfile
        {
            public int id { get; set; }
            public IFormFile video { get; set; }
            public string videourl { get; set; }
            public string descript { get; set; }
            public int courseId { get; set; }
           
        }


    }
}
