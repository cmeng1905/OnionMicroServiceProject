using Azure.Core;
using OnionProject.Application.Abstractions.Services;
using OnionProject.Application.Abstractions.UnitOfWork;
using OnionProject.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Persistence.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWorkRepo _unitOfWorkRepo;

        public UserService(IUnitOfWorkRepo unitOfWorkRepo)
        {
            _unitOfWorkRepo = unitOfWorkRepo;
        }

        public async Task<User> GetAsync(string UserName, string password)
        {
            var user = await _unitOfWorkRepo.UserReadRepository.GetAsync(s => s.UserName == UserName && s.Password == password);
            return user;
        }
    }
}
