using System;
using System.Collections.Generic;
using System.Text;

namespace BEE
{
  public  class teacher
    {
        public int id { get; set; }
        public string name{ get; set; }
        public string family { get; set; }
        public string username{ get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string image { get; set; }
        public List<techer_Cours> Courss_techers { get; set; }



    }
  
  
}
