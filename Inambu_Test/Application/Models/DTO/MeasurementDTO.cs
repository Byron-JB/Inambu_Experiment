namespace Application.Models.DTO
{
    public class MeasurementDTO
    {
        public int MeasurementId { get; set; }
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }
        public decimal Weight { get; set; }
        public decimal Depth { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public bool IsWithinSpecification { get; set; }
        public DateTime CreatedDate { get; set; }
        public string productionLine { get; set; }
        public string CreatedBy { get; set; }
        public bool IsAllowedToEdit { get; set; }
    }
}
