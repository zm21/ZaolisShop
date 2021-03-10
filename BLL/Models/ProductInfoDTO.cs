using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ProductInfoDTO
    {
        public int Id { get; set; }

        public int Count { get; set; }

        public string Color { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Size { get; set; }

        public string Img1 { get; set; }

        public string Img2 { get; set; }

        public List<string> Images{ get; set; }
    }
}
