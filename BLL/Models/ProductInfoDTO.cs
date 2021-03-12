using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ProductInfoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Invalid amount of products")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Invalid color of product")]
        public string Color { get; set; }

        public int ProductId { get; set; }

        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Invalid product name")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Invalid size")]
        public string Size { get; set; }

        [DisplayName("First Image")]
        [Required(ErrorMessage = "Invalid image")]
        public string Img1 { get; set; }

        [DisplayName("Second Image")]
        [Required(ErrorMessage = "Invalid image")]
        public string Img2 { get; set; }

        public List<string> Images{ get; set; }
    }
}
