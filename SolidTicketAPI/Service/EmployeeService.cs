using MediatR;
using SolidTicketAPI.Dtos;
using SolidTicketAPI.Entities;
using SolidTicketAPI.Repo;

namespace SolidTicketAPI.Service
{
  // Çalışan ile ilgi hizmetleri üstlen sınıf
  public class EmployeeService
  {
    // 1.referans
    private EFEmployeeRepo employeeRepo = new EFEmployeeRepo();
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
      var employee = employeeRepo.GetEmployeeById(request.EmployeeId);
      var ticket = ticketRepo.GetTicketById(request.TicketId);

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
