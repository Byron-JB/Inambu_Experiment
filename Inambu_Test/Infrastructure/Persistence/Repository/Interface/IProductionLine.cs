using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository.Interface
{
    public interface IProductionLine
    {
        Task<List<tblProductionLine>> GetAllProductionLines();
        Task<tblProductionLine?> GetProductionLineById(int lineId);
    }
}
