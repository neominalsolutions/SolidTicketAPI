using MediatR;
using DomainLayer;

namespace DomainLayer
{

  // Event Consumer => Handler => event bilgisini tüketen arkadaşlar 
  public class TickedAssignedHandler : INotificationHandler<TicketAssignedEvent>
  {
    // Event fırlatıktan sonra burada notification olarak gelen event bilgileri işlenecek
    // OOP bazlı Event Driven Development yapmış oluyoruz.
    public async Task Handle(TicketAssignedEvent notification, CancellationToken cancellationToken)
    {
      await Task.CompletedTask;
    }
  }
}
