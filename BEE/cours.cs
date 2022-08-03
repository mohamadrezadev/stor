using System;
using System.Collections.Generic;
using System.Text;

namespace BEE
{
   public class cours
    {
        public readonly techer_Cours Teachers;

        public int id { get; set; }
        public string titel { get; set; }
        public string image { get; set; }
        public string video { get; set; }
        public string details { get; set; }
        public  float price { get; set; }
        public  int time { get; set; }

        public List<cours_deteilfile> cours_Deteilfiles { get; set; }
        public List<techer_Cours> Courss_techers { get; set; }

    }
}
