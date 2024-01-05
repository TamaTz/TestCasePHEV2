using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TestCasePHEV2.Models
{
    [Table("tb_user")]
    public class User
    {
        [Key]
        public string Guid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CompanyGuid { get; set; }
        public string RoleGuid { get; set; }

        public virtual ICollection<Company> CompanyUser { get; set; }
        public virtual ICollection<Role> RolesUser { get; set; }
    }
}