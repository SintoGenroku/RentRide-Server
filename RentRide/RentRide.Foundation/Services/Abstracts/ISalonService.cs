using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RentRide.DomainModels;

namespace RentRide.Foundation.Services.Abstracts
{
    public interface ISalonService
    {
        Task<Salon> GetSalonById(Guid id);

        IEnumerable<Salon> GetSalonsByName(string name);

        IEnumerable<Salon> GetSalonsByLocation(string name);

        Task<IReadOnlyCollection<Salon>> GetSalonsAsync();
        
        Task CreateSalonAsync(Salon salon);

        Task UpdateSalonAsync(Salon salon);
    }
}