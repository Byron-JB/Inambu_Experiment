using Domain.Common;
using System.ComponentModel.DataAnnotations;

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
