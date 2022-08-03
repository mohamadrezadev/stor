using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using BEE;
namespace BEE
{
    public class techer_Cours
    {
        public int id { get; set; }
        public int teacherId { get; set; }
        public int courseId { get; set; }

        [ForeignKey("teacherId")]
        public teacher Teachers { get; set; }
        [ForeignKey("courseId")]
        public cours courss { get; set; }
    }
}
