using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository.Interface
{
    public interface IExpenditureApprovalMembers
    {
        Task<int> CreateMemberApprovalEntry(tblExpenditureApprovalMembers approvalMember);

        Task<bool> SetMemberApprovalEntryStatusToRejected(int id);

        Task<bool> SetMemberApprovalEntryStatusToApproved(int id);
    }
}
