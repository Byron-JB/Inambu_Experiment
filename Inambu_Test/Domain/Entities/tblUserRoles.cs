using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class tblUserRoles : AuditableEntity
    {

        public tblUserRoles() { }

        [Key]
        public int iRoleId { get; set; }

        public string strRoleName { get; set; } = string.Empty;
    }
}
