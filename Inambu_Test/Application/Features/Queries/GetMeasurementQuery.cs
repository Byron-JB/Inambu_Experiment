using Application.Models.DTO;
using Infrastructure.Persistence.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries
{

    public record GetMeasurementQuery(int MeasurementId) : IRequest<MeasurementDTO>;

    public class GetMeasurementQueryHandler : IRequestHandler<GetMeasurementQuery, MeasurementDTO>
    {
        private readonly IMeasurement _measurement;
        public GetMeasurementQueryHandler(IMeasurement measurement)
        {
            _measurement = measurement;
        }

        public async Task<MeasurementDTO> Handle(GetMeasurementQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var measurement  = await _measurement.GetMeasurementById(request.MeasurementId);

                return new MeasurementDTO()
                {
                    MeasurementId = measurement!.iMeasurementID,
                    Temperature = measurement.dTemperature,
                    Humidity = measurement.dHumidity,
                    Depth = measurement.dDepth,
                    Weight = measurement.dWeight,
                    Width = measurement.dWidth,
                    Length = measurement.dLength,
                    IsWithinSpecification = measurement.bIsWithinSpecification,
                    CreatedDate = measurement.CreatedDate,
                    productionLine = measurement.ProductionLineNavigation?.strLineName ?? "Unknown"
                };

            }
            catch (Exception)
            {

                throw;
            }

            throw new NotImplementedException();
        }
    }
}
