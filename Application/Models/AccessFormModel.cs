namespace Application.Models;

public class AccessFormModel
{
    public string Code { get; set; } = string.Empty;
    public Guid? SelectedHallId { get; set; }
    public Guid? SelectedCourtId { get; set; }
}