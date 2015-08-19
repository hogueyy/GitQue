using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace GitQuery.Models
{
    public class Commit
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Query Name")]
        public string name { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Dbase db { get; set; }

        [Display(Name = "Created At")]
        [DisplayFormat(DataFormatString = "{0:g}", ApplyFormatInEditMode = true)]
        public DateTime created_at { get; set; }

        [Required]
        [Display(Name = "Username")]
        public String uid { get; set; }
        
        [Required]
        [Display(Name = "Password")]
        public String password { get; set; }

        [Display(Name = "Table")]
        public String table { get; set; }

        [Display(Name = "Records Affected")]
        public int numRows { get; set; }

        [Required]
        [Display(Name = "SQL")]
        public String sqlQuery { get; set; }
        public String key { get; set; }
    }
}