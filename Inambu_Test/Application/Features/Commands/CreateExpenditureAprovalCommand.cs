using Application.Contract.Common;
using Application.Models.DTO;
using Domain.Entities;
using Infrastructure.Persistence.Repository.Interface;
using MediatR;

namespace Application.Features.Commands
{
    public record CreateExpenditureApprovalCommand(ExpenditureAprovalDTO ExpenditureAprovalDTO) : IRequest<CommandResult>;


    public class CreateExpenditureApprovalCommandHandler : IRequestHandler<CreateExpenditureApprovalCommand, CommandResult>
    {
        private readonly IExpenditureRequest _expenditureRequest;
        private readonly IUser _user;
        private readonly IExpenditureApprovalMembers _expenditureApprovalMembers;

        public CreateExpenditureApprovalCommandHandler(IExpenditureRequest expenditureRequest, IUser user, IExpenditureApprovalMembers expenditureApprovalMembers)
        {
            _expenditureRequest = expenditureRequest;
            _user = user;
            _expenditureApprovalMembers = expenditureApprovalMembers;
        }


        public async Task<CommandResult> Handle(CreateExpenditureApprovalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Create an expenditure request and store in the DB
                var requestID = await _expenditureRequest.CreateExpenditureRequestAsync(
                    new tblExpenditureRequest()
                    {
                        strDescription = request.ExpenditureAprovalDTO.Description,
                        strRequestTitle = request.ExpenditureAprovalDTO.Title,
                        dAmount = request.ExpenditureAprovalDTO.Amount,
                        CreatedBy = request.ExpenditureAprovalDTO.userID
                    }
                );

                // Create an appoval entry for the Department Manager
                await _expenditureApprovalMembers.CreateMemberApprovalEntry(
                    new tblExpenditureApprovalMembers()
                    {
                        expenditureRequestId = requestID,
                        iOrder = 0,
                        CreatedBy = request.ExpenditureAprovalDTO.userID,
                        iUserId = await _user.GetUserIdByNameAsync("Bob Lockwood"),
                    }
                );


                // Create an appoval entry for the Financial Director
                if (request.ExpenditureAprovalDTO.Amount > 24999)
                {
                    await _expenditureApprovalMembers.CreateMemberApprovalEntry(
                        new tblExpenditureApprovalMembers()
                        {
                            expenditureRequestId = requestID,
                            iOrder = 0,
                            iUserId = await _user.GetUserIdByNameAsync("Alice Liddle"),
                            CreatedBy = request.ExpenditureAprovalDTO.userID
                        }
                    );
                }

                // Create an appoval entry for the CEO
                if (request.ExpenditureAprovalDTO.Amount > 99999)
                {
                    await _expenditureApprovalMembers.CreateMemberApprovalEntry(
                        new tblExpenditureApprovalMembers()
                        {
                            expenditureRequestId = requestID,
                            iOrder = 0,
                            iUserId = await _user.GetUserIdByNameAsync("Jeff Sidebottom"),
                            CreatedBy = request.ExpenditureAprovalDTO.userID
                        }
                    );
                }


                return CommandResult.Success(requestID);

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
