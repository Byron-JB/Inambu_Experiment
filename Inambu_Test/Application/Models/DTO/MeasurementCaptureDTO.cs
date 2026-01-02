using System.Diagnostics.CodeAnalysis;

namespace Application.Models.DTO
{
    public class MeasurementCaptureDTO
    {
        [SetsRequiredMembers]
        public MeasurementCaptureDTO()
        {

        }

        public required int Temperature { get; set; } = 0;
        public required decimal Humidity { get; set; } = 0;
        public required decimal Weight { get; set; } = 0;
        public required decimal Width { get; set; } = 0;
        public required decimal Length { get; set; } = 0;
        public required decimal Depth { get; set; } = 0;
        public required bool IsWithinSpecification { get; set; } = false;
        public required int ProductionLineID { get; set; } = 0;
        public int UserId { get; set; } = 0;
    }
}
