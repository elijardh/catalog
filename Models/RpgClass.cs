using System.Text.Json.Serialization;

namespace catalog.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RpgClass
    {
        Knight = 1,
        Mage = 2,
        Claric = 3

    }
}