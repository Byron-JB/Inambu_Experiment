using Application.Models.DTO;
using Application.Models.Enum;
using Domain.Entities;
using Infrastructure.Persistence.Repository.Implementation;
using Infrastructure.Persistence.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries
{
    public record GetAllExpenditureRequestsQuery(ExpenditureApprovalFetchTypes ApprovalFetchTypes) : IRequest<List<ExpenditureAprovalDTO>>;

    public class GetAllExpenditureRequestsQueryHandler : IRequestHandler<GetAllExpenditureRequestsQuery, List<ExpenditureAprovalDTO>>
    {
        public readonly IExpenditureRequest _expenditureRequest;
        public readonly IUser _user;

        public GetAllExpenditureRequestsQueryHandler(IExpenditureRequest expenditureRequest, IUser user)
        {
            _expenditureRequest = expenditureRequest;
            _user = user;
        }

        public async Task<List<ExpenditureAprovalDTO>> Handle(GetAllExpenditureRequestsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                switch(request.ApprovalFetchTypes)
                {
                    case ExpenditureApprovalFetchTypes.FetchApproved:
                        return await MapDTOAsync(await _expenditureRequest.GetAllApprovedExpenditureRequestsAsync());

                    case ExpenditureApprovalFetchTypes.FetchPending:
                        return await MapDTOAsync(await _expenditureRequest.GetAllPendingExpenditureRequestsAsync());

                    case ExpenditureApprovalFetchTypes.FetchRejected:
                        return await MapDTOAsync(await _expenditureRequest.GetAllRejectedExpenditureRequestsAsync());
                    default:
                        return new List<ExpenditureAprovalDTO>();
                }
            }
            catch (Exception)
            {

                return new List<ExpenditureAprovalDTO>();
            }
        }

        private async Task<List<ExpenditureAprovalDTO>> MapDTOAsync(List<tblExpenditureRequest> expenditureRequests)
        {
            List<ExpenditureAprovalDTO> approvalDtoList = new List<ExpenditureAprovalDTO>();

            foreach (var request in expenditureRequests)
            {

                string createdUserName = "Unknown";

                if(request.CreatedBy != null)
                    createdUserName = await _user.GetUserNameByIdAsync((int)request.CreatedBy!);

                approvalDtoList.Add(
                    new ExpenditureAprovalDTO()
                    {
                        Description = request.strDescription,
                        Amount = request.dAmount,
                        IsApproved = request.isApproved,
                        IsRejected = request.isRejected,
                        Title = request.strRequestTitle,
                        requestId = request.expenditureRequestId,
                        CreatedBy = createdUserName,
                    }
                );
            }

            return approvalDtoList;
        }
    }


}
