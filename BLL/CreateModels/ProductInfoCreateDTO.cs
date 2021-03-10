using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL.CreateModels
{
    public enum SIZE
    {
        S, M, L, XL
    }
    public class ProductInfoCreateDTO
    {
        [Range(1, int.MaxValue, ErrorMessage = "The number must be greater than zero")]
        public int Count { get; set; }

        public string Color { get; set; }

        public int ProductId { get; set; }

        public SIZE Size { get; set; }

        [Required]
        [DisplayName("Image 1:")]
        public HttpPostedFileBase Img1 { get; set; }

        [Required]
        [DisplayName("Image 2:")]
        public HttpPostedFileBase Img2 { get; set; }
    }
}
