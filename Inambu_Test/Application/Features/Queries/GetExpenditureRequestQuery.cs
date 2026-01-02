using Application.Models.DTO;
using Infrastructure.Persistence.Repository.Interface;
using MediatR;

namespace Application.Features.Queries
{
    public record GetExpenditureRequestQuery(int id) : IRequest<ExpenditureAprovalDTO>;

    public class GetExpenditureRequestQueryHandler : IRequestHandler<GetExpenditureRequestQuery, ExpenditureAprovalDTO>
    {
        private readonly IExpenditureRequest _expenditureRequest;
        private readonly IExpenditureApprovalMembers _expenditureApprovalMembers;
        private readonly IUser _user;

        public GetExpenditureRequestQueryHandler(IExpenditureApprovalMembers expenditureApprovalMembers, IExpenditureRequest expenditureRequest, IUser user)
        {
            _expenditureRequest = expenditureRequest;
            _expenditureApprovalMembers = expenditureApprovalMembers;
            _user = user;
        }
        public async Task<ExpenditureAprovalDTO> Handle(GetExpenditureRequestQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var expenditureRequest = await _expenditureRequest.GetExpenditureRequestAsync(request.id);

                var formattedDTO = new ExpenditureAprovalDTO()
                {
                    Description = expenditureRequest.strDescription,
                    Amount = expenditureRequest.dAmount,
                    IsApproved = expenditureRequest.isApproved,
                    IsRejected = expenditureRequest.isRejected,
                    Title = expenditureRequest.strRequestTitle,
                    requestId = expenditureRequest.expenditureRequestId,
                };

                formattedDTO.ApprovalRecords = expenditureRequest.tblExpenditureApprovalMembersNavigation?
                    .Select(async x => new ExpenditureApprovalRecordsDTO()
                    {
                        ApprovalUserId = (int)x.iUserId,
                        ApprovalUserName = (x.iUserId != null || x.iUserId != 0) ? (await _user.GetUserNameByIdAsync((int)x.iUserId)) : "Unknown",
                        CreatedBy = (x.CreatedBy != null || x.CreatedBy != 0) ? (await _user.GetUserNameByIdAsync((int)x.CreatedBy)) : "Unknown",
                        IsApproved = x.isApproved,
                        IsRejected = x.isRejected,
                    })
                    as List<ExpenditureApprovalRecordsDTO>;

                return formattedDTO;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
