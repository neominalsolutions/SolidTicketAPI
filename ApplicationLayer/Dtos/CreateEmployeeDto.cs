using System.Text.Json.Serialization;

namespace ApplicationLayer
{
    public record CreateEmployeeDto
    {
        [JsonPropertyName("FName")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
