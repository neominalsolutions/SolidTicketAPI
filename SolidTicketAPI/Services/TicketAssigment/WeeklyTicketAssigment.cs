using SolidTicketAPI.Entities;
using SolidTicketAPI.Repos;

namespace SolidTicketAPI.Services.TicketAssigment
{
  public class WeeklyTicketAssigment : ITicketAssigment
  {
    private readonly IRepo<AssignedTicket> _repo;

    public WeeklyTicketAssigment(IRepo<AssignedTicket> repo)
    {
      _repo = repo;
    }

    /// <summary>
    /// Haftalık görev ataması
    /// </summary>
    /// <param name="emp"></param>
    /// <param name="ticket"></param>
    /// <param name="planningHour"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Assign(Employee emp, Ticket ticket, int planningHour)
    {


      var employeeWeeklyAssignedTicketsHour = _repo.Where(x => x.AssignedAt >= DateTime.Now.AddDays(-7).Date && x.AssignedAt.Date <= DateTime.Now && x.EmployeeId == emp.Id).Sum(x => x.PlanningHour);

      if (employeeWeeklyAssignedTicketsHour + planningHour > 30)
      {
        throw new Exception("Haftalık atamanın dışına çıktık");
      }

    }
  }
}
