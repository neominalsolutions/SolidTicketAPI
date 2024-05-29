namespace SolidTicketAPI.Entities
{
  public class AssignedTicket
  {
    public Guid EmployeeId { get; init; }

    // bidirectional association => ilişkileri çift traflı bağlama. Kaos oluşturması sebebi ile böyle bir ilişkiyi uygun görmüyoruz.
    // public Employee Employee { get; set; }

    // Tek taraflı ilişkilerin arayüz ihtiyacına göre bağlanması olayına unidirectional association ismi veriyoruz. Genel olarak karmaşık objelerde bu yöntemi kullanarak geliştirme özen gösteriyoruz.
    public Guid TicketId { get; init; }

    // Law of Demetter kullandık
    public string GetTicketTitle
    {
      get
      {
        return Ticket.Title;
      }
    }

    // Burada da ekranda 
    private Ticket Ticket { get; set; } // field Law of Demeter ile nesne üzerinden diğer nesnelere geçiş olmaması için engelledik. Geçiş yapılan propertylere Navigation Property

    public int PlanningHour { get; init; } // Planlanan saat
    public DateTime AssignedAt { get; init; }

    AssignedTicket(Guid employeeId, Ticket ticket, int planningHour)
    {
      EmployeeId = employeeId;
      TicketId = ticket.Id;
      PlanningHour = planningHour;
      AssignedAt = DateTime.Now;
    }

    public static AssignedTicket Create(Guid employeeId,Ticket ticket,int planningHour)
    {
      return new AssignedTicket(employeeId, ticket, planningHour);
    }
  }
}
