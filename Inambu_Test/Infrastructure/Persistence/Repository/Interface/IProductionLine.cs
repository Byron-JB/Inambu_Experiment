using Domain.Entities;

namespace Infrastructure.Persistence.Repository.Interface
{
    public interface IProductionLine
    {
        Task<List<tblProductionLine>> GetAllProductionLines();
        Task<tblProductionLine?> GetProductionLineById(int lineId);
    }
}
