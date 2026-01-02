using Domain.Entities;
using Infrastructure.Persistence.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository.Implementation
{
    public class ExpenditureApprovalMembers : IExpenditureApprovalMembers, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public ExpenditureApprovalMembers(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context.CreateDbContext();
        }

        public async Task<int> CreateMemberApprovalEntry(tblExpenditureApprovalMembers approvalMember)
        {
            try
            {
                await _context.tblExpenditureApprovalMembers.AddAsync(approvalMember);
                await _context.SaveChangesAsync();

                return approvalMember.iUserId ?? 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
        }

        public async Task<bool> SetMemberApprovalEntryStatusToRejected(int id)
        {
            try
            {
                var itemsUpdated = await _context.tblExpenditureApprovalMembers
                    .Where(x => x.iMemberApprovalEntryId == id)
                    .ExecuteUpdateAsync(
                        x => x.SetProperty(y => y.isRejected, true)
                    );

                return itemsUpdated > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> SetMemberApprovalEntryStatusToApproved(int id)
        {
            try
            {
                var itemsUpdated = await _context.tblExpenditureApprovalMembers
                    .Where(x => x.iMemberApprovalEntryId == id)
                    .ExecuteUpdateAsync(
                        x => x.SetProperty(y => y.isApproved, true)
                    );

                return itemsUpdated > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
