using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Product
    {
        public Product()
        {
            ProductInfos = new HashSet<ProductInfo>();
            Carts = new HashSet<Cart>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }

        public virtual ICollection<ProductInfo> ProductInfos { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
