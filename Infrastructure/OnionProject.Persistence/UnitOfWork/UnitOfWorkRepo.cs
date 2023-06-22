using Microsoft.EntityFrameworkCore;
using OnionProject.Application.Abstractions.Services;
using OnionProject.Application.Abstractions.UnitOfWork;
using OnionProject.Application.Repositories.Product;
using OnionProject.Application.Repositories.User;
using OnionProject.Persistence.Contexts;
using OnionProject.Persistence.Repositories.Product;
using OnionProject.Persistence.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Persistence.UnitOfWork
{
    public class UnitOfWorkRepo : IUnitOfWorkRepo
    {
        private readonly CmengDbContext _cmengDbContext;
        public IUserReadRepository UserReadRepository { get; private set; }

        public IProductReadRepository ProductReadRepository { get; private set; }

        public UnitOfWorkRepo(CmengDbContext cmengDbContext)
        {
            _cmengDbContext = cmengDbContext;
            UserReadRepository = new UserReadRepository(_cmengDbContext);
            ProductReadRepository = new ProductReadRepository(_cmengDbContext);
        }

        public void Save()
        {
            _cmengDbContext.SaveChanges();
        }
    }
}
