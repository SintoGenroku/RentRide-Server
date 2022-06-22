using AutoMapper;
using RentRide.DomainModels;
using RentRide.WebApplication.Models.Requests.Salons;
using RentRide.WebApplication.Models.Responses.Salons;

namespace RentRide.WebApplication.MapperConfigs
{
    public class SalonProfile : Profile
    {
        public SalonProfile()
        {
            CreateMap<Salon, SalonResponseModel>();
            CreateMap<SalonRequestModel, Salon>();
            
        }
    }
}