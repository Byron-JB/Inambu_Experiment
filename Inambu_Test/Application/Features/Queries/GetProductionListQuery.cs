using Application.Contract.Common;
using Application.DTO;
using Infrastructure.Persistence.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries
{

    public record GetProductionListQuery() : IRequest<List<ProductionLineDTO?>>;

    public class GetProductionListQueryHandler : IRequestHandler<GetProductionListQuery, List<ProductionLineDTO?>>
    {
        private readonly IProductionLine _productionLine;
        public GetProductionListQueryHandler(IProductionLine productionLine)
        {
            _productionLine = productionLine;
        }
        public async Task<List<ProductionLineDTO?>> Handle(GetProductionListQuery request, CancellationToken cancellationToken)
        {
            var productionLines = await _productionLine.GetAllProductionLines();
            
            var productionLineDTOs = productionLines.Select(line => new ProductionLineDTO()
            {
                ProductionLineId = line.iLineId,
                ProductionLineName = line.strLineName
            });
            
            if(!productionLineDTOs.Any())
            {
                return [];
            }

            return [.. productionLineDTOs];
        }
    }
}
