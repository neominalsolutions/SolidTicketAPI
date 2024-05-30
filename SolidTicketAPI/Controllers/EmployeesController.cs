using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolidTicketAPI.Dtos;
using SolidTicketAPI.Dtos.Employee;
using SolidTicketAPI.Entities;
using SolidTicketAPI.Services;

namespace SolidTicketAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeesController : ControllerBase
  {
    // Instance alma işlemini program.cs dosyasındaki application bırakıyoruz.
    private readonly IMediator mediator; 
    private readonly EmployeeAssignTicketService employeeAssignTicketService;

    // Ioc Tanıtılan servisleride Constructor üzerinden ilgili class enjecte ediyoruz.
    // Dependency Injection diyoruz
    public EmployeesController(IMediator mediator, EmployeeAssignTicketService employeeAssignTicketService)
    {
      this.mediator = mediator;
      this.employeeAssignTicketService = employeeAssignTicketService;
      // this.mediator = new Mediator()
    }

    [HttpGet]
    public IActionResult Test()
    {
      //Ticket ticket = Ticket.Create("Ticket-1");
      //Employee employee = Employee.Create("Ali", "Can");
      //employee.AssignTicket(ticket, 15, 200); // Haftalık Ticket
      //// Kod blogundan sonraki kısımda event tüketme yapacağız.

      //// Employee Service
      //var @events =  employee.Events;
      //foreach (var @event in @events)
      //{
      //  this.mediator.Publish(@event); // Eventleri yayınlayacağız.
      //  // EventHandler tetiklenecek
      //}

      return Ok();

    }

    [HttpPost]
    public IActionResult Create(CreateEmployeeDto request)
    {

      var employeeService = new EmployeeCreateService();
      employeeService.Create(request);

      return Ok();
    }

    [HttpPost("assignTask")]
    public IActionResult AssignTicketRequest(AssignTicketEmployeeDto request)
    {

      //var employeeService = new EmployeeAssignTicketService(mediator,);
      // instance almak ile uğralmamak için uygulama ne kadar servis instance alınacak ise Program dosyasına tanımı yapıyoruz.
      employeeAssignTicketService.Assign(request);

      return Ok();
    }
  }
}
