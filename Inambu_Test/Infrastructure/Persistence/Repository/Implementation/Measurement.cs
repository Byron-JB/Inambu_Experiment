using Domain.Entities;
using Infrastructure.Persistence.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository.Implementation
{
    public class Measurement : IMeasurement
    {
        private readonly ApplicationDbContext _context;

        public Measurement(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int?> CreateMeasurement(tblMeasurement measurement)
        {
            try
            {
                await _context.tbMeasurements.AddAsync(measurement);
                await _context.SaveChangesAsync();
                return measurement.iMeasurementID;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<List<tblMeasurement>> GetAllMeasurements()
        {
            try
            {
                var measurements = await _context.tbMeasurements
                    .Include(measurement => measurement.ProductionLineNavigation)
                    .Where(measurement => !measurement.IsDeleted)
                    .ToListAsync();

                return measurements;
            }
            catch (Exception)
            {

                return new List<tblMeasurement>();
            }
        }
    }
}
