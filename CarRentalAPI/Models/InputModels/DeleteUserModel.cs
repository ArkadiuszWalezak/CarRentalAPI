using System.Text.Json.Serialization;

namespace CarRentalAPI.Models.InputModels
{
    public class DeleteUserModel
    {
        
            public string name { get; set; }
            public string surname { get; set; }
            public string idNumber { get; set; }
        
    }
}

