using ApplicationLayer;
using ApplicationLayer.Features.Employees;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


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

    [HttpPost("assignTaskWithMediator")]
    public async Task<IActionResult> AssignTicketRequest([FromBody] EmployeeAssignTicketCommand request) {

      // Mediator Kullanarak Controller içerisinde servis referanslarından kurtulduk
      // EmployeeAssignTicketService
      //    employeeAssignTicketService.Assign(request); şu şekilde direct olarak yönledirme yaparken aşağıdaki şekilde indirect communation yapısı kurtuk. GRASP Indirection yapısına örnek.
      await mediator.Send(request);

      return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployeeById([FromRoute] Guid employeeId)
    {
      var query = new GetEmployeeByIdQuery(employeeId);
      var response = await mediator.Send(query);

      return Ok(response);
    }
    
  }
}
