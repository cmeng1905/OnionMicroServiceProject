using OnionProject.Application.Repositories.Common;
using OnionProject.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Repositories.User
{
    public interface IUserWriteRepository:IWriteRepository<Domain.Entities.User.User>
    {
    }
}
