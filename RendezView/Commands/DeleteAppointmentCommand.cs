using MediatR;
using Telerik.Blazor.Components;

namespace RendezView.Commands;

public class DeleteAppointmentCommand : IRequest
{
    public SchedulerDeleteEventArgs EventArgs { get; }

    public DeleteAppointmentCommand(SchedulerDeleteEventArgs eventArgs)
    {
        EventArgs = eventArgs;
    }
}