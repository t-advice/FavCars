using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FavCars.Models
{
    public class Car   // Model class for a car
    {
        [PrimaryKey, AutoIncrement] // SQLite attributes
        public int Id { get; set; }

        public string Name { get; set; }
        public int Year { get; set; }
        public string ImagePath { get; set; }
    

        // Details
        public string Engine { get; set; } // Engine details
        public string Color { get; set; }
        public string FuelType { get; set; }
    }
}
