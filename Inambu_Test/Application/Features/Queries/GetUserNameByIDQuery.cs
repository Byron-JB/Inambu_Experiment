using Infrastructure.Persistence.Repository.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Queries
{
    public record GetUserNameByIDQuery(int userId) : IRequest<string>;

    public class GetUserNameByIdQueryHandler : IRequestHandler<GetUserNameByIDQuery, string>
    {
        private readonly IUser _user;

        public GetUserNameByIdQueryHandler(IUser user) 
        {
            _user = user;
        }

        public async Task<string> Handle(GetUserNameByIDQuery request, CancellationToken cancellationToken)
        {
            try
            {
                
                return await _user.GetUserNameByIdAsync(request.userId);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
