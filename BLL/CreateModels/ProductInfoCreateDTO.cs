using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CreateModels
{
    public class ProductInfoCreateDTO
    {
        public int Count { get; set; }
        public string Color { get; set; }
        public int ProductId { get; set; }
        public string Size { get; set; }
    }
}
