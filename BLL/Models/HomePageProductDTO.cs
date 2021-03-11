using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class HomePageProductDTO
    {
        public List<ProductInfDTO> ProductsNew { get; set; }

        public List<ProductInfDTO> ProductsPopular { get; set; }
        public HomePageProductDTO()
        {
            ProductsNew = new List<ProductInfDTO>();
            ProductsPopular = new List<ProductInfDTO>();
        }
    }
}
