using MediatR;
using Microsoft.EntityFrameworkCore;
using RendezView.Application.Data;
using RendezView.Commands;
using RendezView.Core;

namespace RendezView.Handlers;

public class GetUserDetailHandler : IRequestHandler<GetUserDetailsCommand, User>
{
    private readonly IDbContextFactory<AppointmentsContext> _contextFactory;

    public GetUserDetailHandler(IDbContextFactory<AppointmentsContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<User> Handle(GetUserDetailsCommand request, CancellationToken cancellationToken)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        var userId = request.UserId;
        var user = await context.Users
            .Include(u => u.Contract)
            .FirstOrDefaultAsync(u => u.Id == userId, cancellationToken);
        return user;
    }
}