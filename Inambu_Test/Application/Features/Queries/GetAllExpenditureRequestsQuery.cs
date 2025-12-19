using Application.Models.DTO;
using Application.Models.Enum;
using Domain.Entities;
using Infrastructure.Persistence.Repository.Implementation;
using Infrastructure.Persistence.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries
{
    public record GetAllExpenditureRequestsQuery(ExpenditureApprovalFetchTypes ApprovalFetchTypes) : IRequest<List<ExpenditureAprovalDTO>>;

    public class GetAllExpenditureRequestsQueryHandler : IRequestHandler<GetAllExpenditureRequestsQuery, List<ExpenditureAprovalDTO>>
    {
        public readonly IExpenditureRequest _expenditureRequest;

        public GetAllExpenditureRequestsQueryHandler(IExpenditureRequest expenditureRequest)
        {
            _expenditureRequest = expenditureRequest;
        }

        public async Task<List<ExpenditureAprovalDTO>> Handle(GetAllExpenditureRequestsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                switch(request.ApprovalFetchTypes)
                {
                    case ExpenditureApprovalFetchTypes.FetchApproved:
                        return MapDTO(await _expenditureRequest.GetAllApprovedExpenditureRequestsAsync());

                    case ExpenditureApprovalFetchTypes.FetchPending:
                        return MapDTO(await _expenditureRequest.GetAllPendingExpenditureRequestsAsync());

                    case ExpenditureApprovalFetchTypes.FetchRejected:
                        return MapDTO(await _expenditureRequest.GetAllRejectedExpenditureRequestsAsync());
                    default:
                        return new List<ExpenditureAprovalDTO>();
                }
            }
            catch (Exception)
            {

                return new List<ExpenditureAprovalDTO>();
            }
        }

        private List<ExpenditureAprovalDTO> MapDTO(List<tblExpenditureRequest> expenditureRequests)
        {
            return expenditureRequests.Select(x =>
                new ExpenditureAprovalDTO()
                {
                   Description = x.strDescription,
                   Amount = x.dAmount,
                   IsApproved = x.isApproved,
                   IsRejected = x.isRejected,
                   Title = x.strRequestTitle,
                   requestId = x.expenditureRequestId
                }
            ).ToList();
        }
    }


}
