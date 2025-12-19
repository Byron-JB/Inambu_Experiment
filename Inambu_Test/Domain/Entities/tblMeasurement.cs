using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class tblMeasurement : AuditableEntity
    {
        [Key]
        public int iMeasurementID { get; set; }
        public decimal dTemperature { get; set; }
        public decimal dHumidity { get; set; }
        public decimal dWeight { get; set; }
        public decimal dWidth { get; set; }
        public decimal dLength { get; set; }
        public decimal dDepth { get; set; }
        public required bool bIsWithinSpecification { get; set; } = false;
        public int? iLineId { get; set; }
        [ForeignKey("iLineId")]
        public virtual tblProductionLine? ProductionLineNavigation { get; set; }
    }
}
