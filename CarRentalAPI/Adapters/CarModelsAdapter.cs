using CarRentalAPI.Database;
using CarRentalAPI.Models;
using MySqlConnector;
using System.Windows.Input;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Security.Policy;
using System.Linq;

namespace CarRentalAPI.Adapters
{
    public class CarModelsAdapter
    {
        public static CarModelModel GetCarModel(string name, BrandModel brandModel, TypeModel typeModel)
        {
            if (name == null || typeModel == null || brandModel == null)
            {
                return null;
            }
            using (var connection = DbConnection.Connection)
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"select ID, name from models as m where m.name like @name;";
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
                                typeModel = typeModel,
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static CarModelModel GetCarModel(string modelName)
        {
            if (modelName == null)
            {
                return null;
            }

            using (var connection = DbConnection.Connection)
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT models.ID, models.name, b.name, t.name FROM models LEFT JOIN brands AS b ON brands_id = b.id LEFT JOIN types AS t ON types_id = t.id WHERE models.name = @modelName";
                    command.Parameters.AddWithValue("@modelName", modelName);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new CarModelModel()
                            {
                                ID = reader.GetInt32(0),
                                name = reader.GetString(1),
                                brandModel = new BrandModel() { name = reader.GetString(2) },
                                typeModel = new TypeModel() { name = reader.GetString(3) }
                            };
                        }
                        reader.Close();
                    }
                }
            }
            return null;
        }

        public struct CustomType
        {
            public string Name;
            public string Type;
            public string ContentName;
            public string Surname;
            public string Age;
        }

        public static void XYZ()
        {
            List<CustomType> customTypes = new List<CustomType>();

            for (int i = 0; i < 5; i++)
            {
                customTypes.Add(new CustomType()
                {
                    Name = "Name" + i,
                    Type = "Type" + i,
                    ContentName = "ContentName" + i,
                    Surname = "Surname" + i,
                    Age = "Age" + i,
                });
            }

            var result = customTypes.Where(x => x.Name == "Name5").ToList();
        }

        public static bool InsertNewCarModel(string name, TypeModel typeModel, BrandModel brandModel)
        {
            using (var connection = DbConnection.Connection)
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"INSERT INTO models(name, brands_id, types_id) VALUES (@name, @brands_id, @types.ID)";
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@brands_id", brandModel.ID);
                    command.Parameters.AddWithValue("@types_id", typeModel.ID);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    { }
                }
            }
            return true;
        }
    }
}

