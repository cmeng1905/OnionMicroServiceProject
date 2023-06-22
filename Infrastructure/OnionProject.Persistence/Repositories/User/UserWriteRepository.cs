using OnionProject.Application.Repositories.User;
using OnionProject.Domain.Entities.User;
using OnionProject.Persistence.Contexts;
using OnionProject.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Persistence.Repositories.User
{
    public class UserWriteRepository : WriteRepository<Domain.Entities.User.User>, IUserWriteRepository
    {
        public UserWriteRepository(CmengDbContext context) : base(context)
        {
        }
    }
}
