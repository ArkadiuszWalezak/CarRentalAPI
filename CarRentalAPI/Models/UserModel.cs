﻿using System.Text.Json.Serialization;

namespace CarRentalAPI.Models
{
    public class UserModel
    {
        [JsonIgnore]
        public int ID { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public string idNumber { get; set; }
    }
}
