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
            CartItems = new HashSet<CartItem>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public virtual ICollection<CartItem> CartItems { get; set; }

        [Required]
        public string UserAdditionalInfoId { get; set; }

        [Required]
        public virtual UserAdditionalInfo UserAdditionalInfo { get; set; }
    }
}
