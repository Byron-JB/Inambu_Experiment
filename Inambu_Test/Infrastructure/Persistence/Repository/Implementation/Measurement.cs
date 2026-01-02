using Domain.Entities;
using Infrastructure.Persistence.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository.Implementation
{
    public class Measurement : IMeasurement, IDisposable
    {
        private readonly ApplicationDbContext _context;

        public Measurement(IDbContextFactory<ApplicationDbContext> context)
        {
            _context = context.CreateDbContext();
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

        public async Task<tblMeasurement?> GetMeasurementById(int measurementId)
        {
            try
            {
                return await _context.tbMeasurements
                     .FirstOrDefaultAsync(measurement => measurement.iMeasurementID == measurementId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteMeasurement(int measurementId)
        {
            try
            {
                var measurement = await _context.tbMeasurements
                    .FirstOrDefaultAsync(m => m.iMeasurementID == measurementId);
                if (measurement == null)
                {
                    return false;
                }
                measurement.IsDeleted = true;
                _context.tbMeasurements.Update(measurement);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateMeasurement(tblMeasurement measurement)
        {
            try
            {
                var existingMeasurement = await _context.tbMeasurements
                    .FirstOrDefaultAsync(m => m.iMeasurementID == measurement.iMeasurementID);
                if (existingMeasurement == null)
                {
                    return false;
                }
                existingMeasurement.dTemperature = measurement.dTemperature;
                existingMeasurement.dHumidity = measurement.dHumidity;
                existingMeasurement.dDepth = measurement.dDepth;
                existingMeasurement.dWeight = measurement.dWeight;
                existingMeasurement.dWidth = measurement.dWidth;
                existingMeasurement.dLength = measurement.dLength;
                existingMeasurement.bIsWithinSpecification = measurement.bIsWithinSpecification;
                _context.tbMeasurements.Update(existingMeasurement);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {

        }
    }
}
