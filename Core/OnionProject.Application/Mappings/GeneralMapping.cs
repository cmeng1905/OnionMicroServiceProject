using AutoMapper;
using OnionProject.Application.Dtos.Product;
using OnionProject.Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Mappings
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Urun, ProductDto>();
        }
    }
}
