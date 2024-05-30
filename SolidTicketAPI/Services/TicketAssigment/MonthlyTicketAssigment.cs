using SolidTicketAPI.Entities;
using SolidTicketAPI.Repos;

namespace SolidTicketAPI.Services.TicketAssigment
{

  /// <summary>
  /// Open Close bir işi farklı şekilde yaparken kaynak kodda değişilik olmayacak ama kod gelişime açık olacak. 
  /// </summary>

  public class MonthlyTicketAssigment : ITicketAssigment
  {

    private readonly IRepo<AssignedTicket> _repo;

    public MonthlyTicketAssigment(IRepo<AssignedTicket> repo)
    {
      _repo = repo;
    }


    /// <summary>
    /// Aylık Görev Ataması
    /// </summary>
    /// <param name="emp"></param>
    /// <param name="ticket"></param>
    /// <param name="planningHour"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Assign(Employee emp, Ticket ticket, int planningHour)
    {
      throw new NotImplementedException();
    }
  }
}
