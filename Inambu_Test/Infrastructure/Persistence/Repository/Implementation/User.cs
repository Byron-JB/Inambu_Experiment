using Infrastructure.Persistence.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repository.Implementation
{
    public class User : IUser
    {
        Task<string> IUser.GetUserNameByIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        Task<string> IUser.GetUserNameByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
