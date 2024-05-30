using DomainLayer;
using InfrastrastureLayer;
using MediatR;


namespace ApplicationLayer
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
    private IEmployeeRepository repo; // Interface ile iki sınıfın konuaşağı bir altyapı kurma olayına da Dependency Inversion adı veriyoruz. EFEmployeeRepo veya DapperEmployeeRepo dan birini IoC ile değiştirerek uygulamanın davranışı kodu güncellemeden tek bir yerden değiştirebiliriz.
    private TicketAssigmentManager ticketAssigmentManager;
    public EmployeeAssignTicketService(IMediator mediator, IEmployeeRepository repo, TicketAssigmentManager ticketAssigmentManager)
    {
      this.mediator = mediator;
      this.repo = repo;
      this.ticketAssigmentManager = ticketAssigmentManager;
    }

    public void Assign(AssignTicketEmployeeDto request)
    {
      // var employee = // Repo ile employee Bu
      var employee = repo.GetById(request.EmployeeId);
      var ticket = ticketRepo.GetById(request.TicketId);
      var props = new AssigmentPropertiesDto { AssignmentType = request.AssigmentType, PlanningHour = request.PlanningHour };
      // Application Request Bussiness Layer işlenmesi için gönderdik.
      this.ticketAssigmentManager.OnProcess(props, ticket, employee);

    }
  }
}
