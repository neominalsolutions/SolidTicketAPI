using System.Text.Json.Serialization;

namespace SolidTicketAPI.Dtos.Employee
{
  public record CreateEmployeeDto
  {
    [JsonPropertyName("FName")]
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}
