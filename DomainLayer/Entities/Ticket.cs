namespace DomainLayer
{
  public class Ticket
  {
    public Guid Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public string Title { get; private set; }
    public string? Description { get; private set; }

    Ticket(string title)
    {
      ArgumentNullException.ThrowIfNull(title);
      Id = Guid.NewGuid();
      CreatedAt = DateTime.Now;
      Title = title.Trim();
    }
    public  static Ticket Create(string title)
    {
      return new Ticket(title);
    }

  }
}
