using CarRentalAPI.Database;
using CarRentalAPI.Models;
using MySqlConnector;

namespace CarRentalAPI.Adapters
{
    public class CarsAdapter
    {
        public static bool InsertNewCar(string registrationNumber, string year, string color, CarModelModel carModel)
        {
            using (var connection = DbConnection.Connection)
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO cars(registrationNumber, year, color, models_id) VALUES (@registrationNumber, @year, @color, @models_id)";
                    command.Parameters.AddWithValue("@registrationNumber", registrationNumber);
                    command.Parameters.AddWithValue("@year", year);
                    command.Parameters.AddWithValue("@color", color);
                    command.Parameters.AddWithValue("@models_id", carModel.ID);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    { }
                }
            }
            return true;
        }
    }
}
