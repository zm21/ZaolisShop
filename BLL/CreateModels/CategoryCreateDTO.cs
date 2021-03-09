using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CreateModels
{
    public class CategoryCreateDTO
    {
        [Required]
        [StringLength(maximumLength: 24, ErrorMessage = "Max lenght category name 24 characters")]
        public string Name { get; set; }
    }
}
