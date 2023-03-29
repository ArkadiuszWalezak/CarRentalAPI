namespace CarRentalAPI.Models
{
    public class EmployeeModel
    {
        public int ID { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public UserModel IDx { get; set; }
        public string idNumber { get; set; }
    }
}
