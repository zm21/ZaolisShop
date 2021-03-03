using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Order
    {
        public Order()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string UserAdditionalInfoId { get; set; }

        [Required]
        public int ShippingAdressId { get; set; }

        [Required]
        public string DateOfOrder { get; set; }

        [Required]
        public virtual ICollection<Product> Products { get; set; }

        [Required]
        public virtual ShippingAdress ShippingAdress { get; set; }

        [Required]
        public virtual UserAdditionalInfo UserAdditionalInfo { get; set; }
    }
}
