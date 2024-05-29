using MediatR;
using SolidTicketAPI.Events;

namespace SolidTicketAPI.Handlers
{

  // Event Consumer => Handler => event bilgisini tüketen arkadaşlar 
  public class TickedAssignedHandler : INotificationHandler<TicketAssignedEvent>
  {
    // Event fırlatıktan sonra burada notification olarak gelen event bilgileri işlenecek
    // OOP bazlı Event Driven Development yapmış oluyoruz.
    public Task Handle(TicketAssignedEvent notification, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
