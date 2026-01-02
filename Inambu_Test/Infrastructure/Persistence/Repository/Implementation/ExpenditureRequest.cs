using Domain.Entities;
using Infrastructure.Persistence.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository.Implementation
{
    public class ExpenditureRequest : IExpenditureRequest, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public ExpenditureRequest(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<tblExpenditureRequest> GetExpenditureRequestAsync(int Id)
        {
            try
            {
                tblExpenditureRequest? expenditureRequest = await _context.tblExpenditureRequests
                    .Include(x => x.tblExpenditureApprovalMembersNavigation)
                    .FirstOrDefaultAsync(x => x.expenditureRequestId == Id);

                if (expenditureRequest == null)
                    return new tblExpenditureRequest();

                return expenditureRequest;

            }
            catch (Exception)
            {

                return new tblExpenditureRequest();
            }
        }

        public async Task<int> CreateExpenditureRequestAsync(tblExpenditureRequest expenditureRequest)
        {
            try
            {
                await _context.tblExpenditureRequests.AddAsync(expenditureRequest);
                await _context.SaveChangesAsync();

                return expenditureRequest.expenditureRequestId;

            }
            catch (Exception)
            {

                return 0;
            }
        }

        public async Task<List<tblExpenditureRequest>> GetAllPendingExpenditureRequestsAsync()
        {
            try
            {
                var requests = await _context.tblExpenditureRequests
                    .Include(x => x.tblExpenditureApprovalMembersNavigation)
                    .Where(x => x.isRejected == false
                        && x.IsDeleted == false
                        && x.IsActive == true
                        && x.isApproved == false
                    )
                    .ToListAsync();

                return requests;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<tblExpenditureRequest>> GetAllApprovedExpenditureRequestsAsync()
        {
            try
            {
                var requests = await _context.tblExpenditureRequests
                    .Where(x => x.isRejected == false
                        && x.IsDeleted == false
                        && x.IsActive == true
                        && x.isApproved == true
                    )
                    .ToListAsync();

                return requests;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<tblExpenditureRequest>> GetAllRejectedExpenditureRequestsAsync()
        {
            try
            {
                var requests = await _context.tblExpenditureRequests
                    .Where(x => x.isRejected == true
                        && x.IsDeleted == false
                        && x.IsActive == true
                        && x.isApproved == false
                    )
                    .ToListAsync();

                return requests;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> SetExpenditureRequestToRejected(int id)
        {
            try
            {
                var recordsSaved = await _context.tblExpenditureRequests
                    .Where(x => x.expenditureRequestId == id)
                    .ExecuteUpdateAsync(x => x.SetProperty(y => y.isRejected, true)
                    );

                return recordsSaved > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> SetExpenditureRequestToApproved(int id)
        {
            try
            {
                var recordsSaved = await _context.tblExpenditureRequests
                    .Where(x => x.expenditureRequestId == id)
                    .ExecuteUpdateAsync(x => x.SetProperty(y => y.isApproved, true)
                    );

                return recordsSaved > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Dispose()
        {
        }
    }
}
