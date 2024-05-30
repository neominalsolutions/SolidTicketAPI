using MediatR;
using SolidTicketAPI.Dtos;
using SolidTicketAPI.Dtos.Employee;
using SolidTicketAPI.Entities;
using SolidTicketAPI.Repos;
using SolidTicketAPI.Services.TicketAssigment;

namespace SolidTicketAPI.Services
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
    private TicketAssigmentManager ticketAssigmentManager;
    public EmployeeAssignTicketService(IMediator mediator, IRepo<Employee> repo, TicketAssigmentManager ticketAssigmentManager)
    {
      this.mediator = mediator;
      this.repo = repo;
      this.ticketAssigmentManager = ticketAssigmentManager;
    }

    public void Assign(AssignTicketEmployeeDto request)
    {
      // var employee = // Repo ile employee Bu
      var employee = repo.GetById(request.EmployeeId);
      var ticket = ticketRepo.GetTicketById(request.TicketId);
      var props = new AssigmentPropertiesDto { AssignmentType = request.AssigmentType, PlanningHour = request.PlanningHour };
      // Application Request Bussiness Layer işlenmesi için gönderdik.
      this.ticketAssigmentManager.OnProcess(props, ticket, employee);

      var @events = employee.Events;
      foreach (var @event in @events)
      {
        this.mediator.Publish(@event); // Eventleri yayınlayacağız.
        // EventHandler tetiklenecek
      }
    }
  }
}
