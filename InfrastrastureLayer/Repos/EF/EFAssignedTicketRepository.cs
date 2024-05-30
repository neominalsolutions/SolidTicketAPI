
using DomainLayer;
using System.Linq;
using System.Linq.Expressions;

namespace InfrastrastureLayer
{
    public class EFAssignedTicketRepository : IAssignedTicketRepository
    {
        public void Delete(AssignedTicket Id)
        {
            throw new NotImplementedException();
        }



        public AssignedTicket GetById(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Insert(AssignedTicket employee)
        {
            throw new NotImplementedException();
        }

        public void Update(AssignedTicket employee)
        {
            throw new NotImplementedException();
        }



        public IEnumerable<AssignedTicket> Where(Expression<Func<AssignedTicket, bool>> predicate)
        {
            List<AssignedTicket> tickets = new List<AssignedTicket>();

            var t1 = AssignedTicket.Create(employeeId: new Guid("c8aa3433-84ac-4ee2-b460-aea312fc6f47"), Ticket.Create("Ticket-1"), 2);

            var t2 = AssignedTicket.Create(employeeId: new Guid("c8aa3433-84ac-4ee2-b460-aea312fc6f47"), Ticket.Create("Ticket-1"), 3);

            var t3 = AssignedTicket.Create(employeeId: new Guid("c8aa3433-84ac-4ee2-b460-aea312fc6f47"), Ticket.Create("Ticket-1"), 5);
            t3.SetAssignedAt(DateTime.Now.AddDays(-2));

            var t4 = AssignedTicket.Create(employeeId: new Guid("c8aa3433-84ac-4ee2-b460-aea312fc6f47"), Ticket.Create("Ticket-1"), 6);
            t4.SetAssignedAt(DateTime.Now.AddDays(-10));

            var t5 = AssignedTicket.Create(employeeId: new Guid("37988caf-2df1-498b-8abe-33e22fadb7a4"), Ticket.Create("Ticket-1"), 3);


            tickets.Add(t1);
            tickets.Add(t2);
            tickets.Add(t3);
            tickets.Add(t4);
            tickets.Add(t5);

            return tickets.AsQueryable().Where(predicate).AsEnumerable();
        }
    }
}
