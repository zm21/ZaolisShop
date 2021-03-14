using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL.CreateModels
{
    public class ProductCreateDTO
    {
        [Required]
        [MaxLength(32, ErrorMessage = "The name must be no longer than 32 characters")]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "The Description must be no longer than 1000 characters")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string CategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public ProductCreateDTO()
        {
            Categories = new List<SelectListItem>();
        }
    }
}
