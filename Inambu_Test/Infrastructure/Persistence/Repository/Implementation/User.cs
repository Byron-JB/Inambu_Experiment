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
    public class User : IUser,IDisposable
    {
        private readonly ApplicationDbContext _context;

        public User( IDbContextFactory<ApplicationDbContext> context ) 
        {
            _context = context.CreateDbContext();
        }

        public async Task<string> GetUserNameByIdAsync(int userId)
        {
            try
            {
                if (userId == 0) return string.Empty;

                if (userId == -1) return "System";

                var user = await _context.tblUsers
                    .FirstOrDefaultAsync(x => x.iUserId == userId);

                return user?.strUserName ?? string.Empty;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> GetUserIdByNameAsync(string userName)
        {
            try
            {
                var user = await _context.tblUsers
                    .Where(x => x.strUserName == userName)
                    .Select(x => x.iUserId)
                    .FirstOrDefaultAsync();

                return user;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<tblUser>> GetAllUsersAsync()
        {
            try
            {
                var users = _context.tblUsers
                    .Where(x => x.IsDeleted == false
                        && x.IsActive == true)
                    .ToListAsync();

                return users;

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void Dispose()
        {
        }
    }
}
