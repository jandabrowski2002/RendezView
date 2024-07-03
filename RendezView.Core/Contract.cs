namespace RendezView.Core;

public class Contract
{
    public int Id { get; set; }
    public string Type { get; set; }
    public int LeaveDaysAmount { get; set; }
    public DateTime StartDate { get; set; }
    public User User { get; set; }
    public int? UserId { get; set; }
}