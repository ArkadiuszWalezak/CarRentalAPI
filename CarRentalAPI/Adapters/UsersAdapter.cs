using CarRentalAPI.Database;
using CarRentalAPI.Models;
using CarRentalAPI.Models.InputModels;
using MySqlConnector;

namespace CarRentalAPI.Adapters
{
    public class UsersAdapter
    {
        public static UserModel GetSpecificUser(string name, string surname, string idNumber)
        {
            using (var connection = DbConnection.Connection)
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"select * from users as u where u.name like @name and u.surname like @surname and u.idNumber like @idNumber";
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@surname", surname);
                    command.Parameters.AddWithValue("@idNumber", idNumber);

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

        public static bool InsertNewUser(string name, string surname, string phone, string idNumber)
        {
            using (var connection = DbConnection.Connection)
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO users (name, surname, phone, idNumber) VALUES (@name, @surname, @phone, @idNumber)";
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@surname", surname);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@idNumber", idNumber);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    { }
                }
            }
            return true;
        }
        public static bool UpdateUser(UserModel user, string newUserName, string newUserSurname, string newUserPhone, string newUserIdNumber)
        {
            using (var connection = DbConnection.Connection)
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE users AS u SET u.name = @name, u.surname = @surname, u.phone = @phone, u.idNumber = @idNumber WHERE u.id = @id";
                    command.Parameters.AddWithValue("@name", newUserName);
                    command.Parameters.AddWithValue("@surname", newUserSurname);
                    command.Parameters.AddWithValue("@phone", newUserPhone);
                    command.Parameters.AddWithValue("@idNumber", newUserIdNumber);
                    command.Parameters.AddWithValue("@id", user.ID);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    { }
                }
            }
            return true;
        }

        public static bool DeleteUser(DeleteUserModel user)
        {
            using (var connection = DbConnection.Connection)
            {
                connection.Open();
                string st = $"DELETE FROM users WHERE name = '{user.name}' AND surname = '{user.surname}' AND idNumber = '{user.idNumber}'";
                MySqlCommand command = new MySqlCommand(st, connection);
                {
                    command.ExecuteNonQuery();
                    //using (MySqlDataReader reader = command.ExecuteReader()) //(ciekawe dlaczego wywala tutaj błąd)
                    //{ }
                }
            }
            return true;
        }

    }
}
