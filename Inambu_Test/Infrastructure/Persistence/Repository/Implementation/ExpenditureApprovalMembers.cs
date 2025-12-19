using Domain.Entities;
using Infrastructure.Persistence.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }
    }
}
