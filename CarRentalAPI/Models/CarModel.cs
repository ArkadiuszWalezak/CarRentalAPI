using System.Text.Json.Serialization;

namespace CarRentalAPI.Models
{
    public class CarModel
    {
        [JsonIgnore]
        public int ID { get; set; }
        public string registrationNumber { get; set; }
        public string year { get; set; }
        public string color { get; set; }
        public CarModelModel carModel { get; set; }
    }
}
