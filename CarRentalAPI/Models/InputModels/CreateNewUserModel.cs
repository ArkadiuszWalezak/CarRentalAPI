using System.Text.Json.Serialization;

namespace CarRentalAPI.Models.InputModels
{
    public class CreateNewUserModel
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public string idNumber { get; set; }
    }
}
