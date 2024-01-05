using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestCasePHEV2.Models
{
    [Table("tb_role")]
    public class Role
    {
        [Key]
        public string Guid { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> UserRole { get; set; }
    }
}