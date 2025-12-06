using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Perisitence
{
    public class ApplicationDBInitializer
    {
        private readonly ApplicationDbContext _context;

        public ApplicationDBInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Initialize the database by applying migrations if the database is SQL Server.
        /// </summary>
        /// <returns></returns>
        public async Task InitializeAsync()
        {
            try
            {
                if (_context.Database.IsSqlServer())
                {
                    await _context.Database.MigrateAsync();
                    SeedData();
                }



            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Seeds initial data into the database.
        /// </summary>
        public void SeedData()
        {
            // Seed initial data if necessary
            SeedUsers();
            SeedProductionLines(); 
            SeedMeasurements();
        }

        /// <summary>
        /// Adds seed users to the database if no users exist.
        /// </summary>
        public void SeedUsers()
        {

            if (!_context.tblUsers.Any())
            {
                _context.tblUsers.AddRange(Seeds.GetSeedUsers());
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Adds seed production lines to the database if no production lines exist.
        /// </summary>
        public void SeedProductionLines()
        {
            if (!_context.tblProductionLines.Any())
            {
                _context.tblProductionLines.AddRange(Seeds.GetSeedProductionLines());
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Adds seed measurements to the database if no measurements exist.
        /// </summary>
        public async Task SeedMeasurements()
        {
            if (!_context.tbMeasurements.Any())
            {
                await _context.tbMeasurements.AddRangeAsync(Seeds.GetSeedMeasurements());
                await _context.SaveChangesAsync();

                //Link productions lines tomeasurements
                var productionLine = await _context.tblProductionLines.FirstOrDefaultAsync();

                await _context.tbMeasurements
                    .Where(measurement => measurement.ProductionLineNavigation == null)
                    .ExecuteUpdateAsync(
                        m => m.SetProperty(
                            measurement => measurement.ProductionLineNavigation,
                            measurement => productionLine)
                    );
            }
        }

    }
}
