using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BEE
{
   
    public   class User: IdentityUser
    {
       
        public string name { get; set; }
        public string family { get; set; }
        public string  pic{ get; set; }
        public List<cours> list_courss{ get; set; }
        
    }
}
