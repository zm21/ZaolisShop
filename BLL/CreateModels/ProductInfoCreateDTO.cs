using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CreateModels
{
    public class ProductInfoCreateDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "The number must be greater than zero")]
        public int Count { get; set; }

        public string Color { get; set; }

        public int ProductId { get; set; }

        public string Size { get; set; }
    }
}
