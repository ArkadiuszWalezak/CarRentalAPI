using CarRentalAPI.Database;
using CarRentalAPI.Models;
using CarRentalAPI.Models.InputModels;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using System.Drawing;
using System.Reflection;

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
        public static bool DeleteCar(DeleteCarModel car)
        {
            using (var connection = DbConnection.Connection)
            {
                connection.Open();
                string st = $"DELETE FROM cars WHERE registrationNumber = '{car.registrationNumber}'";
                MySqlCommand command = new MySqlCommand(st, connection);
                {
                    command.ExecuteNonQuery();
                    //using (MySqlDataReader reader = command.ExecuteReader()) //(ciekawe dlaczego wywala tutaj błąd)
                    //{ }
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }


    }
}
