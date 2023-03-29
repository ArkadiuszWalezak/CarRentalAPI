using System.Text.Json.Serialization;

namespace CarRentalAPI.Models.InputModels
{
    public class CreateNewCarModelModel
    {
        public string name { get; set; }
        public BrandModel brandModel { get; set; }
        public TypeModel typeModel { get; set; }

    }

}
