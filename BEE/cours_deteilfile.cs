using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEE
{
  public class cours_deteilfile
    {
        public int id { get; set; }
        public string addres { get; set; }
        public string descript { get; set; }
        public int courseId { get; set; }
        [ForeignKey("courseId")]
        public cours courss { get; set; }
    }
}
