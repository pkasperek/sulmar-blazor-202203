using System.Text.Json.Serialization;

namespace Shopper.Domain.Models;

public class Customer : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public GenderType? Gender { get; set; }
    public string? Avatar { get; set; }
}