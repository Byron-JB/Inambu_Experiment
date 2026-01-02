using Domain.Entities;

namespace Infrastructure.Persistence.Repository.Interface
{
    public interface IUser
    {
        Task<string> GetUserNameByIdAsync(int userId);
        Task<int> GetUserIdByNameAsync(string userName);
        Task<List<tblUser>> GetAllUsersAsync();

    }
}
