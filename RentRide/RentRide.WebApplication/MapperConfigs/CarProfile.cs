using AutoMapper;
using RentRide.DomainModels;
using RentRide.WebApplication.Models.Requests.Cars;
using RentRide.WebApplication.Models.Responses.Cars;

namespace RentRide.WebApplication.MapperConfigs
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarResponseModel>();
            CreateMap<CarRequestModel, Car>();
            CreateMap<EditCarRequestModel, Car>();
        }
    }
}