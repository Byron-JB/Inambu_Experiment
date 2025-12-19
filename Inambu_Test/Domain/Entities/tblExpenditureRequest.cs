using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class tblExpenditureRequest : AuditableEntity
    {
        [SetsRequiredMembers]
        public tblExpenditureRequest()
        {
        }

        [Key]
        public int expenditureRequestId { get; set; }

        public required string strRequestTitle { get; set; } = String.Empty;

        public required string strDescription { get; set; } = string.Empty;

        public decimal dAmount { get; set; } = 0;
        public bool isApproved { get; set; } = false;
        public bool isRejected { get; set; } = false;

        public virtual List<tblExpenditureApprovalMembers>? tblExpenditureApprovalMembersNavigation {get;set; }
    }
}
