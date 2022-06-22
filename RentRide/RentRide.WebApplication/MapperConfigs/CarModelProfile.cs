using AutoMapper;
using RentRide.DomainModels;
using RentRide.WebApplication.Models.Requests.CarModels;
using RentRide.WebApplication.Models.Responses.CarModels;

namespace RentRide.WebApplication.MapperConfigs
{
    public class CarModelProfile : Profile
    {
        public CarModelProfile()
        {
            CreateMap<CarModel, CarModelResponseModel>(); 
            CreateMap<CarModelRequestModel, CarModel>(); 
            
        }
    }
}