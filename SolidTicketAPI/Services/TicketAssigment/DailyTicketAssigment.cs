using SolidTicketAPI.Entities;
using SolidTicketAPI.Repos;

namespace SolidTicketAPI.Services.TicketAssigment
{
  public class DailyTicketAssigment : ITicketAssigment
  {
    private readonly IRepo<AssignedTicket> _repo;

    public DailyTicketAssigment(IRepo<AssignedTicket> repo)
    {
      _repo = repo;
    }

    // Günlük assign etme algoritması olsun
    public void Assign(Employee emp, Ticket ticket, int planningHour)
    {

      var employeeDailyAssignedTicketsHour = _repo.Where(x => x.AssignedAt.Date == DateTime.Now.Date && x.EmployeeId == emp.Id).Sum(x=> x.PlanningHour);

      if(employeeDailyAssignedTicketsHour + planningHour > 6)
      {
        throw new Exception("Günlük atamanın dışına çıktık");
      }

      // burada veri tabanına stat güncel olarak gidiyor.
      emp.AssignTicket(ticket, planningHour, 100); // emp state değişti, emp nesnesi içerisinde yeni ticket eklendi.
      // _repo.save();
      // unitOfWork.commit();
    }
  }
}
