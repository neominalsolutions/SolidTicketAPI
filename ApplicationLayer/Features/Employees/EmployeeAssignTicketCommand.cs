using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Features.Employees
{

  // Commandalar ve Query application gelen istekler oluyor
  // Dtodaki bilgileri Commanda yada query nesnelerini gönderebiliriz
  public record EmployeeAssignTicketCommand: IRequest
  {
    public Guid EmployeeId { get; set; }
    public Guid TicketId { get; set; }
    public int AssigmentType { get; set; } = 100;
    public int PlanningHour { get; set; }

  }
}
