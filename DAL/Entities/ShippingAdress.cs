using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ShippingAdress
    {
        public ShippingAdress()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Adress { get; set; }

        public int Appartment { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string PostalCode { get; set; }

        public string Phone { get; set; }

        [Required]
        //[ForeignKey("UserAdditionalInfo")]
        public string UserAdditionalInfoId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual UserAdditionalInfo UserAdditionalInfo { get; set; }
    }
}
