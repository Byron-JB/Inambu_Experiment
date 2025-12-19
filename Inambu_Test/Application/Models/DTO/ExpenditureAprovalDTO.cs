using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.DTO
{
    public class ExpenditureAprovalDTO
    {
        public int requestId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
        public int userID { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    }
}
