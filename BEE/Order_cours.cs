using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEE
{
   public class Order_cours
    {
        public int Id { get; set; }
        public string userid { get; set; }
        public int coursId { get; set; }
        [ForeignKey("userid")]
        public User user { get; set; }
        [ForeignKey("coursId")]
        public cours cours { get; set; }
        
    }
}
