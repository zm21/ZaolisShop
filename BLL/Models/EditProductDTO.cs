using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BLL.Models
{
    public class EditProductDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [DisplayName("Category")]
        public string CategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public EditProductDTO()
        {
            Categories = new List<SelectListItem>();
        }
    }
    
}
