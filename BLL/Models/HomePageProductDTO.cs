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
        public List<ProdutcInfDTO> ProductsNew { get; set; }

        public List<ProdutcInfDTO> ProductsPopular { get; set; }
        public HomePageProductDTO()
        {
            ProductsNew = new List<ProdutcInfDTO>();
            ProductsPopular = new List<ProdutcInfDTO>();
        }
    }
}
