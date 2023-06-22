using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionProject.Application.Dtos.Product
{
    public class ProductDto
    {
        public string Id { get; set; }

        public int UrunId { get; set; }

        public decimal Fiyat { get; set; }

        public string Olcu { get; set; }

        public int Kdv { get; set; }

        public int? Otv { get; set; }

        public string Tanim { get; set; }

        public string Marka { get; set; }

        public string UrunNumara { get; set; }
    }
}
