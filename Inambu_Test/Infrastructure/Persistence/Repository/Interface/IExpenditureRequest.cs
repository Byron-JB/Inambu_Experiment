using Domain.Entities;

namespace Infrastructure.Persistence.Repository.Interface
{
    public interface IExpenditureRequest
    {
        Task<tblExpenditureRequest> GetExpenditureRequestAsync(int Id);
        Task<int> CreateExpenditureRequestAsync(tblExpenditureRequest expenditureRequest);
        Task<List<tblExpenditureRequest>> GetAllPendingExpenditureRequestsAsync();
        Task<List<tblExpenditureRequest>> GetAllApprovedExpenditureRequestsAsync();
        Task<List<tblExpenditureRequest>> GetAllRejectedExpenditureRequestsAsync();
        Task<bool> SetExpenditureRequestToRejected(int id);
        Task<bool> SetExpenditureRequestToApproved(int id);
    }
}
