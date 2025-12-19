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
            SeedUserRoles().ConfigureAwait(true).GetAwaiter();
            SeedUsers().ConfigureAwait(true).GetAwaiter();
            SeedProductionLines().ConfigureAwait(true).GetAwaiter();
            SeedMeasurements().ConfigureAwait(true).GetAwaiter();
        }

        /// <summary>
        /// Creates the user types for the system
        /// </summary>
        public async Task SeedUserRoles()
        {
            if (!_context.tblUserRoles.Any()) 
            {
                await _context.tblUserRoles.AddRangeAsync(Seeds.GetSeedUserRoles());
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Adds seed users to the database if no users exist.
        /// </summary>
        public async Task SeedUsers()
        {

            if (!_context.tblUsers.Any())
            {
                await _context.tblUsers.AddRangeAsync(Seeds.GetSeedUsers());
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Adds seed production lines to the database if no production lines exist.
        /// </summary>
        public async Task SeedProductionLines()
        {
            if (!_context.tblProductionLines.Any())
            {
                await _context.tblProductionLines.AddRangeAsync(Seeds.GetSeedProductionLines());
                await _context.SaveChangesAsync();
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
