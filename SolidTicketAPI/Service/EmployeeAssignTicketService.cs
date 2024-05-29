using MediatR;
using SolidTicketAPI.Dtos;
using SolidTicketAPI.Dtos.Employee;
using SolidTicketAPI.Entities;
using SolidTicketAPI.Repo;

namespace SolidTicketAPI.Service
{
  // Nokta atışı eğer çalışana görevi assign etmemiz gerekirse bu durumda sadece bu süreçten etkielenecek olan service burasıdır.
  // Single Responsibity uyguladık.
  public class EmployeeAssignTicketService
  {
    // 3.referans
    //private EFEmployeeRepo employeeRepo = new EFEmployeeRepo();
    // private DapperEmployeeRepo employeeRepo = new DapperEmployeeRepo();
   
    private TicketRepo ticketRepo = new TicketRepo();
    private IMediator mediator;
    private IRepo<Employee> repo; // Interface ile iki sınıfın konuaşağı bir altyapı kurma olayına da Dependency Inversion adı veriyoruz. EFEmployeeRepo veya DapperEmployeeRepo dan birini IoC ile değiştirerek uygulamanın davranışı kodu güncellemeden tek bir yerden değiştirebiliriz.
    public EmployeeAssignTicketService(IMediator mediator, IRepo<Employee> repo)
    {
      this.mediator = mediator;
      this.repo = repo;
    }

    public void Assign(AssignTicketEmployeeDto request)
    {
      // var employee = // Repo ile employee Bu
      var employee = repo.GetById(request.EmployeeId);
      var ticket = ticketRepo.GetTicketById(request.TicketId);

      employee.AssignTicket(ticket, request.PlanningHour, request.AssigmentType);

      var @events = employee.Events;
      foreach (var @event in @events)
      {
        this.mediator.Publish(@event); // Eventleri yayınlayacağız.
        // EventHandler tetiklenecek
      }
    }
  }
}
