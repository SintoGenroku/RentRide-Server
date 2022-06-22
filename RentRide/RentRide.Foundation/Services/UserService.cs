using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using RentRide.Data;
using RentRide.DomainModels;
using RentRide.Foundation.Services.Abstracts;

namespace RentRide.Foundation.Services
{
    public class UserService : IUserService
    {
        private readonly IRentRideUnitOfWork _unitOfWork;


        public UserService(IRentRideUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);

            if (user == null)
            {
                throw new NotFoundException("User do not exist");
            }
            
            return user;
        }

        public async Task<IReadOnlyCollection<User>> GetUsersAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();

            return users;
        }

        public async Task DeleteUsersAsync(User user)
        { 
            await _unitOfWork.Users.DeleteAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await _unitOfWork.Users.UpdateAsync(user);
        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string userDoNotExist)
        {
            throw new NotImplementedException();
        }
    }
}
