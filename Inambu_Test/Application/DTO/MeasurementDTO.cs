using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class MeasurementDTO
    {
        public int MeasurementId { get; set; }
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }     
        public decimal Weight { get; set; }
        public decimal Depth { get; internal set; }
        public decimal Width { get; internal set; }
        public decimal Length { get; internal set; }
        public bool IsWithinSpecification { get; internal set; }
        public DateTime CreatedDate { get; internal set; }
        public string productionLine { get; set; }
    }
}
