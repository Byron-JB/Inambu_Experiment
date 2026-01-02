using Domain.Entities;
using Infrastructure.Persistence.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository.Implementation
{
    public class ProductionLine : IProductionLine, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public ProductionLine(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context.CreateDbContext(); ;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fetch all production lines
        /// </summary>
        /// <returns></returns>
        public async Task<List<tblProductionLine>> GetAllProductionLines()
        {
            try
            {
                var productionLines = await _context.tblProductionLines
                    .Where(pl => !pl.IsDeleted)
                    .ToListAsync();
                return productionLines;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Fetch a production line by its ID
        /// </summary>
        /// <param name="lineId"></param>
        /// <returns></returns>
        public async Task<tblProductionLine?> GetProductionLineById(int lineId)
        {
            try
            {
                var productionLine = await _context.tblProductionLines
                    .FirstOrDefaultAsync(pl => pl.iLineId == lineId && !pl.IsDeleted);
                return productionLine;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
