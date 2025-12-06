using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository.Interface
{
    public interface IUser
    {
        Task<string> GetUserNameByIdAsync(int userId);
        Task<string> GetUserNameByNameAsync(string userName);
    }
}
