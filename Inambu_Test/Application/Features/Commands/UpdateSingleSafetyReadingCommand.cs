using Application.Contract.Common;
using Application.Models.DTO;
using Infrastructure.Persistence.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands
{

    public record UpdateSingleMeasurementCommand(MeasurementDTO measurementDTO) : IRequest<CommandResult>;


    public class UpdateSingleMeasurementCommandHandler : IRequestHandler<UpdateSingleMeasurementCommand, CommandResult>
    {
        private readonly IMeasurement _measurement;

        public UpdateSingleMeasurementCommandHandler(IMeasurement measurement)
        {
            _measurement = measurement;
        }

        public async Task<CommandResult> Handle(UpdateSingleMeasurementCommand request, CancellationToken cancellationToken)
        {
            try
            {
                bool hasMeasurementBeenUpdated = await _measurement.UpdateMeasurement(new Domain.Entities.tblMeasurement()
                {
                    iMeasurementID = request.measurementDTO.MeasurementId,
                    dTemperature = request.measurementDTO.Temperature,
                    dHumidity = request.measurementDTO.Humidity,
                    dDepth = request.measurementDTO.Depth,
                    dWeight = request.measurementDTO.Weight,
                    dWidth = request.measurementDTO.Width,
                    dLength = request.measurementDTO.Length,
                    bIsWithinSpecification = request.measurementDTO.IsWithinSpecification,
                    CreatedDate = request.measurementDTO.CreatedDate
                });

                return CommandResult.Success(hasMeasurementBeenUpdated);
            }
            catch (Exception)
            {

                throw;
            }        
        }
    }


}
