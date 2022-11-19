using CarRentalAPI.Database;
using CarRentalAPI.Models;
using MySqlConnector;

namespace CarRentalAPI.Adapters
{
    public class BrandsAdapter
    {
        public static BrandModel GetBrand(string name)
        {
            using (var connection = DbConnection.Connection)
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"select * from brands as b where b.name like @name";
                    command.Parameters.AddWithValue("@name", name);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new BrandModel()
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
    }
}
