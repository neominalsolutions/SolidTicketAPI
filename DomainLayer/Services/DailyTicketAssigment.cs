using DomainLayer;

namespace DomainLayer
{
  public class DailyTicketAssigment : ITicketAssigment
  {
    // Infra katmanı ile haberleşme adapter oldu
    // Adapter Design Pattern uyguladı
    // Aynı zamanda DIP prensibinide sistemelerin zayıf bağlılığı için uygulamış olduk.
    private readonly IAssignedTicketRepository _repo;

    public DailyTicketAssigment(IAssignedTicketRepository repo)
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
