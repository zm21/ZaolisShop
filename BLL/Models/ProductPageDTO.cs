using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Models
{
    public class ProductPageDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public List<string> Images { get; set; }
        public List<string> Colors { get; set; }
        public List<string> Sizes { get; set; }

        public string SelectedColor { get; set; }
        public string SelectedSize { get; set; }
    }
}
