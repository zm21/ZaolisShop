using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Cart
    {
        public Cart()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public virtual ICollection<Product> Products { get; set; }

        [Required]
        public string UserAdditionalInfoId { get; set; }

        [Required]
        public virtual UserAdditionalInfo UserAdditionalInfo { get; set; }
    }
}
