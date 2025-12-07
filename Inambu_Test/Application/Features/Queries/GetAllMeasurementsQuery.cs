using Application.Models.DTO;
using Infrastructure.Persistence.Repository.Interface;
using MediatR;

namespace Application.Features.Queries
{

    public record GetAllMeasurementsQuery() : IRequest<List<MeasurementDTO>>;

    public class GetAllMeasurementsQueryHandler : IRequestHandler<GetAllMeasurementsQuery, List<MeasurementDTO>>
    {
        private readonly IMeasurement _measurement;
        public GetAllMeasurementsQueryHandler(IMeasurement measurement)
        {
            _measurement = measurement;
        }
        public async Task<List<MeasurementDTO>> Handle(GetAllMeasurementsQuery request, CancellationToken cancellationToken)
        {
            var measurements = await _measurement.GetAllMeasurements();

            if (measurements.Any())
            {
               return measurements.Select( measurement => new MeasurementDTO()
                {
                    MeasurementId = measurement.iMeasurementID,
                    Temperature = measurement.dTemperature,
                    Humidity = measurement.dHumidity,
                    Depth = measurement.dDepth,
                    Weight = measurement.dWeight,
                    Width = measurement.dWidth,
                    Length = measurement.dLength,
                    IsWithinSpecification = measurement.bIsWithinSpecification,
                    CreatedDate = measurement.CreatedDate,
                    productionLine = measurement.ProductionLineNavigation?.strLineName ?? "Unknown"
                }).ToList();

            }

            return [];
            //return [.. measurementDTOs];
        }
    }
}
