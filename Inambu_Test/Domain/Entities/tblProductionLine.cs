using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class tblProductionLine : AuditableEntity
    {
        [Key]
        public int iLineId { get; set; }

        public required string strLineName { get; set; }
    }
}
