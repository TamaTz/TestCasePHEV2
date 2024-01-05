using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestCasePHEV2.Models
{
    [Table("tr_approvel")]
    public class Approvel
    {
        [Key]
        public string Guid { get; set; }
        public string CompanyGuid { get; set; }

        public virtual ICollection<Company> CompanyApprovel { get; set; }
    }
}