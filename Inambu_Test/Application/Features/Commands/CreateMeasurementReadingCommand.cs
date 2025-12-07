using Application.Contract.Common;
using Application.Models.DTO;
using Domain.Entities;
using Infrastructure.Persistence.Repository.Implementation;
using Infrastructure.Persistence.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public record CreateMeasurementReadingCommand(MeasurementCaptureDTO SafetyCapture) : IRequest<CommandResult>;


    public class CreateMeasurementReadingCommandHandler : IRequestHandler<CreateMeasurementReadingCommand, CommandResult>
    {
        private readonly IMeasurement _measurement;
        private readonly IProductionLine _productionLine;

        public CreateMeasurementReadingCommandHandler(IMeasurement measurement,IProductionLine productionLine)
        {
            _measurement = measurement;
            _productionLine = productionLine;
        }

        public async Task<CommandResult> Handle(CreateMeasurementReadingCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Creating Safety Reading:");

            var productionLine = await _productionLine.GetProductionLineById(request.SafetyCapture.ProductionLineID);

            if(productionLine == null)
            {
                return CommandResult.Failure(
                    new Error(System.Net.HttpStatusCode.NotFound,"Invalid Production Line ID"),request.SafetyCapture);
            }

            tblMeasurement measurement = new tblMeasurement()
            {
                CreatedDate = DateTime.Now,              
                dTemperature = request.SafetyCapture.Temperature,
                dHumidity = request.SafetyCapture.Humidity,
                dDepth = request.SafetyCapture.Depth,
                dWeight = request.SafetyCapture.Weight,
                dWidth = request.SafetyCapture.Width,
                bIsWithinSpecification = request.SafetyCapture.IsWithinSpecification,
                ProductionLineNavigation = productionLine
            };

            int? measurementID = await _measurement.CreateMeasurement(measurement);

            return CommandResult.Success(measurementID);
        }

    }
}
