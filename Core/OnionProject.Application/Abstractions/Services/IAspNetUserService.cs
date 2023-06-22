using OnionProject.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Abstractions.Services
{
    public interface IAspNetUserService
    {
        Task<User> GetAsync(string UserName);
    }
}
