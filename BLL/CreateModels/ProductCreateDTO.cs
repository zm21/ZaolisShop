using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.CreateModels
{
    public class ProductCreateDTO
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public int Count { get; set; }

        public string Color { get; set; }

        public string Size { get; set; }
    }
}
