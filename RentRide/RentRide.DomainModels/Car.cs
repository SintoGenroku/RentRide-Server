using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentRide.DomainModels
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public CarModel CarModel { get; set; }
        public Guid CarModelId { get; set; }
        public Salon Salon { get; set; }
        public Contract RentContract { get; set; }
        public string SerialNumber { get; set; }

    }
}