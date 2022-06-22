using AutoMapper;
using RentRide.DomainModels;
using RentRide.WebApplication.Models.Requests.Users;

namespace RentRide.WebApplication.MapperConfigs
{
    public class UserProfile : Profile 
    {
        public UserProfile()
        {
            CreateMap<UserRegistrationRequestModel, User>()
                .ForMember(dest => dest.UserName,
                    opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Fullname,
                    opt => opt.MapFrom(src => src.Fullname));
        }
    }
}