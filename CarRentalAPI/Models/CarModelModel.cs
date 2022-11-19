using System;
using System.Text.Json.Serialization;

namespace CarRentalAPI.Models
{
    public class CarModelModel
    {
        [JsonIgnore]
        public int ID { get; set; }
        public string name { get; set; }
        public BrandModel brandModel { get; set; }
        public TypeModel typeModel { get; set; }
    }
}
