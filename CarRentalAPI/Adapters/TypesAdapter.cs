using CarRentalAPI.Database;
using CarRentalAPI.Models;
using CarRentalAPI.Models.InputModels;
using MySqlConnector;
using System;
using System.Reflection.Metadata.Ecma335;

namespace CarRentalAPI.Adapters
{
    public class TypesAdapter
    {
        public static TypeModel GetType(string name)
        {
            using (var connection = DbConnection.Connection)
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"select * from types as t where t.name like @name";
                    command.Parameters.AddWithValue("@name", name);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new TypeModel()
                            {
                                ID = reader.GetInt32(0),
                                name = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static bool InsertNewType(string name)
        {
            using (var connection = DbConnection.Connection)
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO types(name) VALUES (@name)";
                    command.Parameters.AddWithValue("@name", name);
                  
                    using (MySqlDataReader reader = command.ExecuteReader())
                    { }
                }
            }

            return true;
        }

        public static bool UpdateType(TypeModel type, string newNameModel)
        {
            using (var connection = DbConnection.Connection)
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"UPDATE types AS t SET t.name = @name WHERE t.id = @id";
                    command.Parameters.AddWithValue("@name", newNameModel);
                    command.Parameters.AddWithValue("@id", type.ID);


                    using (MySqlDataReader reader = command.ExecuteReader())
                    { }
                }
            }

            return true;
        }

        public static bool DeleteType(DeleteTypeModel type)
        {
            using(var connection = DbConnection.Connection)
            {
                connection.Open();
                string st = $"DELETE FROM types WHERE name = '{type.nameTypeModel}'";
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
