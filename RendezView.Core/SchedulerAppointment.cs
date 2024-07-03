using System.ComponentModel.DataAnnotations;

namespace RendezView.Core;

public class SchedulerAppointment
{
    [Key] public int Id { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public bool IsAllDay { get; set; }
    public string? Description { get; set; }
}