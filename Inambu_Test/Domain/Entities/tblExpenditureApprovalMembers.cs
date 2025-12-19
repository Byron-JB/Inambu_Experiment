using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class tblExpenditureApprovalMembers : AuditableEntity
    {
        public tblExpenditureApprovalMembers() { }

        [Key]
        public int Id { get; set; }
        public int iOrder { get; set; } = 0;
        public bool isApproved { get; set; } = false;

        public bool isRejected { get; set; } = false;

        public int? iUserId { get; set; }
        public virtual tblUser? User { get; set; }
        public int? expenditureRequestId {  get; set; }
        public virtual tblExpenditureRequest? ExpenditureRequest { get; set; }


    }
}
