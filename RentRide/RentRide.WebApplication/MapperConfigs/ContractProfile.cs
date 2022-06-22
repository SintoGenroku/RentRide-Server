using AutoMapper;
using RentRide.DomainModels;
using RentRide.WebApplication.Models.Requests.Contracts;
using RentRide.WebApplication.Models.Responses.Contracts;

namespace RentRide.WebApplication.MapperConfigs
{
    public class ContractProfile : Profile
    {
        public ContractProfile()
        {
            CreateMap<Contract, ContractResponseModel>();
            CreateMap<ContractRequestModel, Contract>();
        }
    }
}