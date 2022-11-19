using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalAPI.Models.InputModels
{
    public class CreateNewCarModel
    {
        public string registrationNumber { get; set; }
        public string year { get; set; }
        public string color { get; set; }
        public CarModelModel carModel { get; set; }
    }
}
