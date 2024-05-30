using MediatR;
using ApplicationLayer;
using InfrastrastureLayer;

namespace ApplicationLayer
{
  // Çalışan ile ilgi hizmetleri üstlen sınıf
  public class EmployeeService
  {
    // 1.referans
    private EFEmployeeRepository employeeRepo = new EFEmployeeRepository();
    private TicketRepo ticketRepo = new TicketRepo();
    private IMediator mediator;

    public EmployeeService(IMediator mediator)
    {
      this.mediator = mediator;
    }

    public void Create(EmployeeDto request)
    {

    }

    public void Update(EmployeeDto request)
    {

    }

    public void Remove(Guid Id)
    {

    }

    public void AssignTicket(EmployeeTicketDo request)
    {
      // var employee = // Repo ile employee Bu
      var employee = employeeRepo.GetById(request.EmployeeId);
      var ticket = ticketRepo.GetById(request.TicketId);

      employee.AssignTicket(ticket,request.PlanningHour,request.AssigmentType);

      var @events = employee.Events;
      foreach (var @event in @events)
      {
        this.mediator.Publish(@event); // Eventleri yayınlayacağız.
        // EventHandler tetiklenecek
      }
    }

  }
}
