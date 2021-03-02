using DAL.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    [Table("tblUserAdditionalInfo")]
    public class UserAdditionalInfo
    {
        public UserAdditionalInfo()
        {
            Orders = new HashSet<Order>();
            ShippingAdresses = new HashSet<ShippingAdress>();
        }

        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        

        [Required]
        public string LastName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<ShippingAdress> ShippingAdresses { get; set; }
    }
}
