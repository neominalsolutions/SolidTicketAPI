namespace ApplicationLayer
{
  public class EmployeeTicketDo
  {
    public int PlanningHour { get; set; }
    public Guid EmployeeId { get; set; }
    public Guid TicketId { get; set; }

    public int AssigmentType { get; set; } = 100;



  }
}
