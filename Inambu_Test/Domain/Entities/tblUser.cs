using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class tblUser : AuditableEntity
    {
        [Key]
        public int iUserId { get; set; }
        public required string strUserName { get; set; }
        public int? iRoleId { get; set; }
        public virtual tblUserRoles? Roles { get; set; }
    }
}
