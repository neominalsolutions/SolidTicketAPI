using DomainLayer;
using MediatR;
using System.Collections.Immutable;

namespace DomainLayer
{
  // Mediatr paketi ile Event Driven Development yapabiliriz
  public class Employee
  {
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public string Email { get; private set; }

    private List<AssignedTicket> assignedTickets = new List<AssignedTicket>();
    public IReadOnlyList<AssignedTicket> AssignedTickets => assignedTickets.ToImmutableList();

    private List<INotification> events = new List<INotification>();

    public IReadOnlyList<INotification> Events => events;

    Employee(string firstName, string lastName)
    {
      
      ArgumentNullException.ThrowIfNull(firstName);
      ArgumentNullException.ThrowIfNull(lastName);
      Id = Guid.NewGuid();
      FirstName = firstName.Trim();
      LastName = lastName.Trim().ToUpper();
    }

   

    public static Employee Create(string firstName,string lastName)
    {
      return new Employee(firstName, lastName);
    }

    public void SetEmail(string email)
    {
      ArgumentNullException.ThrowIfNull(email);
      if (!email.Contains("@"))
        throw new ArgumentException("Email formatında değil");

      Email = email;
    }

    // assigmentType => 100 Daily Günlük, 200 Weekly, 300 Monthly
    public void AssignTicket(Ticket ticket, int planningHour, int assigmentType)
    {

      //// Günlük bir görev atamasımı yoksa haftalık mı yoksa aylık mı
      //// Hangi Solid Prensip daha uygun ?
      //if(assigmentType == 100)
      //{
      //  // Daily
      //  // throw new TicketAssigmentException("Günlük en falza 6 saati geçemez");
      //}
      //else if(assigmentType == 200)
      //{
      //  // Weekly
      //  // throw new TicketAssigmentException("Haftalık en falza 30 saati geçemez");
      //}
      //else if(assigmentType == 300)
      //{
      //  // Monthly

      //  // throw new TicketAssigmentException("Aylık en falza 150 saati geçemez");
      //}


      assignedTickets.Add(AssignedTicket.Create(Id, ticket, planningHour));

      events.Add(new TicketAssignedEvent(Id,ticket.Id,planningHour));
      // Sonraki aşama Nesne üzerinde eklenen eventleri çalıştır aşaması


      // Ticket Assigment işlemi gerçekleştireceğiz.
      // Burada Ticket atandıktaa sonra event fırlat.
      // Ticket Assigned event
      // aynı zamanda Exception fırlat
    }
  }
}
