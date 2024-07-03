using MediatR;
using RendezView.Core;

namespace RendezView.Commands;

public class GetUserDetailsCommand : IRequest<User>
{
    public int UserId { get; }

    public GetUserDetailsCommand(int userId)
    {
        UserId = userId;
    }
}