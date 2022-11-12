using CarRentalAPI.Database;
using CarRentalAPI.Models;
using MySqlConnector;

namespace CarRentalAPI.Adapters
{
    public class UsersAdapter
    {
        public static UserModel GetSpecificUser(string name, string surname)
        {
            using (var connection = DbConnection.Connection)
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"select * from users as u where u.name like @name and u.surname like @surname ";
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@surname", surname);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new UserModel()
                            {
                                ID = reader.GetInt32(0),
                                name = reader.GetString(1),
                                surname = reader.GetString(2),
                                phone = reader.GetString(3),
                                idNumber = reader.GetString(4)
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
