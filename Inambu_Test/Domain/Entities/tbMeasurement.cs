using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class tbMeasurement : AuditableEntity
    {
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }
        public decimal Weight { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public decimal Depth { get; set; }
        public required bool IsWithinSpecification { get; set; } = false;
    }
}
