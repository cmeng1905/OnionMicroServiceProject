using AutoMapper;
using OnionProject.Application.Abstractions.Services;
using OnionProject.Application.Abstractions.UnitOfWork;
using OnionProject.Application.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Persistence.Services
{
    public class ProductService : IProductService
    {
        private IUnitOfWorkRepo _unitOfWorkRepo;
        private IMapper _mapper;

        public ProductService(IUnitOfWorkRepo unitOfWorkRepo, IMapper mapper)
        {
            _unitOfWorkRepo = unitOfWorkRepo;
            _mapper = mapper;
        }

        public List<ProductDto> GetProducts()
        {            
            var products = _unitOfWorkRepo.ProductReadRepository.GetAll();
            return _mapper.Map<List<ProductDto>>(products);
        }
    }
}