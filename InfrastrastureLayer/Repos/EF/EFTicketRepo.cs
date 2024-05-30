

using DomainLayer;
using DomainLayer.Repositories;
using System.Linq.Expressions;

namespace InfrastrastureLayer
{
  public class TicketRepo : ITicketRepository
  {
    public void Delete(Ticket Id)
    {
      throw new NotImplementedException();
    }

    public Ticket GetById(Guid Id)
    {
      return Ticket.Create("Ticket-1");
    }

    public void Insert(Ticket employee)
    {
      throw new NotImplementedException();
    }

    public void Update(Ticket employee)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Ticket> Where(Expression<Func<Ticket, bool>> predicate)
    {
      throw new NotImplementedException();
    }
  }
}
