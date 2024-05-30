using InfrastructureCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{

  // Domain katmanı üzerinden Application Infrasture yani uygulamanın altyapı implementasyonlarına erişmemizi sağlayan bir port yada adapter oldu.
  public interface IAssignedTicketRepository:IRepo<AssignedTicket>
  {
  }
}
