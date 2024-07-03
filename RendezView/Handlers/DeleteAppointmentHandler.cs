using MediatR;
using Microsoft.EntityFrameworkCore;
using RendezView.Application.Data;
using RendezView.Commands;
using RendezView.Core;

namespace RendezView.Handlers;

public class DeleteAppointmentHandler : IRequestHandler<DeleteAppointmentCommand>
{
    private readonly AppointmentsContext _dbContext;

    public DeleteAppointmentHandler(AppointmentsContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
    {
        var e = request.EventArgs;
        var apt = e.Item as SchedulerAppointment;
        _dbContext.Appointments.Remove(apt);
        _dbContext.SaveChangesAsync(cancellationToken);
        return Task.FromResult(Unit.Value);
    }
}