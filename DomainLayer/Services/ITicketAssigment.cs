using DomainLayer;

namespace DomainLayer
{
  public interface ITicketAssigment
  {
    /// <summary>
    /// Bussiness Service 
    /// Hangi çalışan Hangi işin assign edileceğini söyler
    /// </summary>
    /// <param name="emp"></param>
    /// <param name="ticket"></param>
    /// <param name="planningHour"></param>
    void Assign(Employee emp, Ticket ticket, int planningHour);
  }
}
