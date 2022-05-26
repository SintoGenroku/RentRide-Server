using System;
using System.Collections.Generic;

namespace RentRide.DomainModels
{
    public class CarModel : DomainObject
    {
        public int Year { get; set; }
        public string Model { get; set; }
        public string Engine { get; set; }
        public string Carcase { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public float RentCoefficient { get; set; }
        public ICollection<Car> Cars { get; set; }

    }
}
