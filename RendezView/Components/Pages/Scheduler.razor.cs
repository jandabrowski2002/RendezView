using Microsoft.EntityFrameworkCore;
using RendezView.Commands;
using RendezView.Core;
using Telerik.Blazor;
using Telerik.Blazor.Components;

namespace RendezView.Components.Pages;

public partial class Scheduler
{
    private DateTime SchedulerStartDate { get; set; } = DateTime.Today;
    private SchedulerView SchedulerCurrentView { get; set; } = SchedulerView.Month;
    private DateTime DayStart { get; set; } = new DateTime(2000, 1, 1, 6, 0, 0);
    private DateTime DayEnd { get; set; } = new DateTime(2000, 1, 1, 19, 0, 0);
    private List<User> UsersList { get; set; } = [];
    private List<Contract> ContractList { get; set; } = [];
    private List<SchedulerAppointment> AppointmentsList = new List<SchedulerAppointment>();
    private bool CustomEditFormShown { get; set; }
    public SchedulerAppointment AppointmentInstance { get; set; } = new();

    private async Task InitDb()
    {
        var contract1 = new Contract()
        {
            Id = 1,
            LeaveDaysAmount = 26,
            StartDate = Convert.ToDateTime("2023-10-10"),
            Type = "b2b"
        };
        var contract2 = new Contract()
        {
            Id = 2,
            LeaveDaysAmount = 26,
            StartDate = Convert.ToDateTime("2023-10-09"),
            Type = "uop"
        };
        var contract3 = new Contract()
        {
            Id = 3,
            LeaveDaysAmount = 26,
            StartDate = Convert.ToDateTime("2023-05-05"),
            Type = "b2b"
        };
        DbContext.Add(contract1);
        DbContext.Add(contract2);
        DbContext.Add(contract3);
        await DbContext.SaveChangesAsync();

        var user1 = new User(
            1,
            "Test",
            "User",
            "test@gmail.com",
            contract1
        );

        var user2 = new User(
            2,
            "Test2",
            "User2",
            "test2@gmail.com",
            contract2
        );

        var user3 = new User(
            3,
            "Test3",
            "User3",
            "test3@gmail.com",
            contract3
        );
        DbContext.Add(user1);
        DbContext.Add(user2);
        DbContext.Add(user3);
        await DbContext.SaveChangesAsync();
    }
    
    protected override async Task OnInitializedAsync()
    {
        await ReloadDataAsync();
    }

    public void CloseHandler()
    {
        CustomEditFormShown = false;
    }
    private async Task ReloadDataAsync()
    {
        AppointmentsList = await DbContext.Appointments.ToListAsync();
        StateHasChanged();
    }

    private async Task OnEdit(SchedulerEditEventArgs? e)
    {
        e.IsCancelled = true;
        CustomEditFormShown = true;
        await ReloadDataAsync();
    }

    private async Task CreateAppointment()
    {
        var command = new CreateAppointmentCommand(AppointmentInstance);
        await Mediator.Send(command);
        CustomEditFormShown = false;
        await ReloadDataAsync();
    }

    private async Task DeleteAppointment(SchedulerDeleteEventArgs e)
    {
        var command = new DeleteAppointmentCommand(e);
        await Mediator.Send(command);
        await ReloadDataAsync();
    }
}