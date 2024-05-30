using System.Text.Json.Serialization;

namespace ApplicationLayer
{
  public class EmployeeDto
  {
    [JsonPropertyOrder(1)]
    [JsonPropertyName("fName")]
    public string FirstName { get; set; }
    public string LastName { get; set; }


  }
}
