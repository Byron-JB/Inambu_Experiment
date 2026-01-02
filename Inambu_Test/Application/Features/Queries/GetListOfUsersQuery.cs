using Infrastructure.Persistence.Repository.Interface;
using MediatR;

namespace Application.Features.Queries
{
    public record GetListOfUsersQuery() : IRequest<Dictionary<int, string>>;

    public class GetListOfUsersQueryHandler : IRequestHandler<GetListOfUsersQuery, Dictionary<int, string>>
    {
        private readonly IUser _user;
        public GetListOfUsersQueryHandler(IUser user)
        {
            _user = user;
        }

        public async Task<Dictionary<int, string>> Handle(GetListOfUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var userList = await _user.GetAllUsersAsync();

                return userList.ToDictionary(
                    user => user.iUserId,
                    user => user.strUserName
                    );

            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
