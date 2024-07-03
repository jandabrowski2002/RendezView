using MediatR;
using Microsoft.EntityFrameworkCore;
using RendezView.Application.Data;
using RendezView.Commands;
using RendezView.Core;

namespace RendezView.Handlers;

public class CreateAppointmentHandler : IRequestHandler<CreateAppointmentCommand>
{
    private readonly AppointmentsContext _dbContext;

    public CreateAppointmentHandler(AppointmentsContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
    {
        var e = request.Appointment;
        _dbContext.Appointments.Add(e);
       await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
