using System.Text.Json.Serialization;

namespace CarRentalAPI.Models
{
    public class TypeModel
    {
        [JsonIgnore]
        public int ID { get; set; }
        public string name { get; set; }
    }
}
