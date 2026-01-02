using Infrastructure.Persistence.Repository.Interface;
using MediatR;

namespace Application.Features.Commands
{
    public record RejectExpenditureRequestCommand(int requestID) : IRequest<bool>;

    public class RejectExpenditureRequestCommandHandler : IRequestHandler<RejectExpenditureRequestCommand, bool>
    {
        private readonly IExpenditureRequest _expenditureRequest;
        private readonly IExpenditureApprovalMembers _expenditureApprovalMembers;

        public RejectExpenditureRequestCommandHandler(IExpenditureApprovalMembers expenditureApprovalMembers, IExpenditureRequest expenditureRequest)
        {
            _expenditureApprovalMembers = expenditureApprovalMembers;
            _expenditureRequest = expenditureRequest;
        }

        public async Task<bool> Handle(RejectExpenditureRequestCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var expenditureRequest = await _expenditureRequest.GetExpenditureRequestAsync(request.requestID);

                var rejectExpenditureRequestresult = await _expenditureRequest.SetExpenditureRequestToRejected(request.requestID);

                var firstNonApprovedEntry = expenditureRequest.tblExpenditureApprovalMembersNavigation
                    .Where(x => x.isApproved == false)
                    .OrderBy(x => x.iOrder)
                    .FirstOrDefault();

                var rejectMemberApprovalStateResult = await _expenditureApprovalMembers.SetMemberApprovalEntryStatusToRejected(firstNonApprovedEntry.iMemberApprovalEntryId);

                return rejectExpenditureRequestresult && rejectMemberApprovalStateResult;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
