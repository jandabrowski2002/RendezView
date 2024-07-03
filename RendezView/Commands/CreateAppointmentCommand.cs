using MediatR;
using RendezView.Core;
using Telerik.Blazor.Components;

namespace RendezView.Commands;

public class CreateAppointmentCommand : IRequest
{
    public SchedulerAppointment Appointment { get; }

    public CreateAppointmentCommand(SchedulerAppointment appointment)
    {
        Appointment = appointment;
    }
}