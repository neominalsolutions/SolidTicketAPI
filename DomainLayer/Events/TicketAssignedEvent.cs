using MediatR;

namespace DomainLayer
{

  // Event olarak kullanılabilmesi için bu şekilde bir tanımlama yaptık
  // Sadece bir olay sonrası olaşan bilgiyi taşımaktan sorumlu sınıf.
  public class TicketAssignedEvent:INotification
  {
    public Guid EmployeeId { get; init; }
    public Guid TicketId { get; init; }
    public int PlanningHour { get; init; }

    public TicketAssignedEvent(Guid employeeId, Guid ticketId, int planningHour)
    {
      EmployeeId = employeeId;
      TicketId = ticketId;
      PlanningHour = planningHour;
    }

  }
}
