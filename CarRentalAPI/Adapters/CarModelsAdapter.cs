using CarRentalAPI.Database;
using CarRentalAPI.Models;
using MySqlConnector;

namespace CarRentalAPI.Adapters
{
    public class CarModelsAdapter
    {
        public static CarModelModel GetCarModel(string name, BrandModel brandModel, TypeModel typeModel)
        {
            if(brandModel == null || typeModel == null)
            {
                return null;
            }

            using (var connection = DbConnection.Connection)
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"select * from models as m where m.name like @name";
                    command.Parameters.AddWithValue("@name", name);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new CarModelModel()
                            {
                                ID = reader.GetInt32(0),
                                name = reader.GetString(1),
                                brandModel = brandModel,
                                typeModel = typeModel
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
