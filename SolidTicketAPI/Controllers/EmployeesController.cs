using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SolidTicketAPI.Dtos;
using SolidTicketAPI.Entities;
using SolidTicketAPI.Service;

namespace SolidTicketAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeesController : ControllerBase
  {
    // Instance alma işlemini program.cs dosyasındaki application bırakıyoruz.
    private readonly IMediator mediator;

    public EmployeesController(IMediator mediator)
    {
      this.mediator = mediator;
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
    public IActionResult Create(EmployeeDto request)
    {

      var employeeService = new EmployeeService(mediator);
      employeeService.Create(request);

      return Ok();
    }

    [HttpPost("assignTask")]
    public IActionResult AssignTicketRequest(EmployeeTicketDo request)
    {

      var employeeService = new EmployeeService(mediator);
      employeeService.AssignTicket(request);

      return Ok();
    }
  }
}
