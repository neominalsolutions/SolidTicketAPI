using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Features.Employees
{
  public record GetEmployeeByIdQuery:IRequest<EmployeeDto>
  {
    private Guid EmployeeId { get; init; }
    public GetEmployeeByIdQuery(Guid employeeId)
    {
      EmployeeId = employeeId;
    }
  }
}
