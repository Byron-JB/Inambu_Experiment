using Application.Models.DTO;
using Infrastructure.Persistence.Repository.Interface;
using MediatR;

namespace Application.Features.Queries
{

    public record GetAllMeasurementsQuery(int userId) : IRequest<List<MeasurementDTO>>;

    public class GetAllMeasurementsQueryHandler : IRequestHandler<GetAllMeasurementsQuery, List<MeasurementDTO>>
    {
        private readonly IMeasurement _measurement;
        private readonly IUser _user;
        public GetAllMeasurementsQueryHandler(IMeasurement measurement, IUser user)
        {
            _measurement = measurement;
            _user = user;
        }
        public async Task<List<MeasurementDTO>> Handle(GetAllMeasurementsQuery request, CancellationToken cancellationToken)
        {
            var measurements = new List<MeasurementDTO>();

            var measurementsFromDB = await _measurement.GetAllMeasurements();

            if (measurementsFromDB.Any())
            {
                foreach (var measurement in measurementsFromDB)
                {
                    measurements.Add(new MeasurementDTO()
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
                        productionLine = measurement.ProductionLineNavigation?.strLineName ?? "Unknown",
                        CreatedBy = await _user.GetUserNameByIdAsync((int)measurement.CreatedBy!),
                        IsAllowedToEdit = (request.userId == measurement.CreatedBy)
                    }
                    );

                }
                return measurements;
            }

            return [];
        }
    }
}
