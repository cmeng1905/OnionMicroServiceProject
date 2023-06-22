using OnionProject.Application.Repositories;
using OnionProject.Application.Repositories.User;
using OnionProject.Domain.Entities.User;
using OnionProject.Persistence.Contexts;
using OnionProject.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Persistence.Repositories.User
{
    public class UserReadRepository : ReadRepository<Domain.Entities.User.User>, IUserReadRepository
    {
        public UserReadRepository(CmengDbContext context) : base(context)
        {
        }
    }
}
