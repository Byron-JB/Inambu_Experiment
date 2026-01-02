using Domain.Entities;

namespace Infrastructure.Persistence.Repository.Interface
{
    public interface IExpenditureApprovalMembers
    {
        Task<int> CreateMemberApprovalEntry(tblExpenditureApprovalMembers approvalMember);

        Task<bool> SetMemberApprovalEntryStatusToRejected(int id);

        Task<bool> SetMemberApprovalEntryStatusToApproved(int id);
    }
}
