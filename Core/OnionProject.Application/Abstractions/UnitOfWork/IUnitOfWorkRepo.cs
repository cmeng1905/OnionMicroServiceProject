using OnionProject.Application.Repositories.Product;
using OnionProject.Application.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Abstractions.UnitOfWork
{
    public interface IUnitOfWorkRepo
    {
        IUserReadRepository UserReadRepository { get;}

        IProductReadRepository ProductReadRepository { get; }

        void Save();

    }
}
