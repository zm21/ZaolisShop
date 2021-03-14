using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ProductInfo
    {
        public ProductInfo()
        {
            Images = new HashSet<Image>();
            CartItems = new HashSet<CartItem>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string Size { get; set; }

        public virtual Product Product { get; set; }
        
        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
