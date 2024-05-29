namespace SolidTicketAPI.Dtos.Employee
{
  public record CreateEmployeeDto
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}
