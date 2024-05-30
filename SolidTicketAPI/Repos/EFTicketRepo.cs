using SolidTicketAPI.Entities;

namespace SolidTicketAPI.Repos
{
  public class TicketRepo
  {
    public Ticket GetTicketById(Guid Id)
    {
      return Ticket.Create("Ticket-1");
    }

    public void Insert(Ticket ticket)
    {
      Console.WriteLine("Kayıt girildi");
    }

    public void Update(Ticket ticket)
    {
      Console.WriteLine("Kayıt Güncellendi");
    }

    public void Delete(Guid Id)
    {
      Console.WriteLine("Kayıt Silindi");
    }
  }
}
