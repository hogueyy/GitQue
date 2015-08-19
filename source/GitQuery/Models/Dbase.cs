using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GitQuery.Models
{
    public class Dbase
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Database Name")]
        public string name { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        [Display(Name = "Server")]
        public String server { get; set; }
        public Boolean authenticated { get; set; }

        public virtual List<Commit> commits { get; set; }
        public int badCommit { get; set; }

        [Required]
        [Display(Name = "Type")]
        public String dbType { get; set; }

        public Dbase()
        {
            authenticated = false;
            badCommit = -1;
        }
    }
}