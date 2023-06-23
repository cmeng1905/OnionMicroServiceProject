using OnionProject.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Abstractions.Services
{
    public interface IUserService
    {
        Task<User> GetAsync(string UserName, string password);
    }
}
