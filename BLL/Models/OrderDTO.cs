using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string UserAdditionalInfoId { get; set; }
        public string ShippingAdress { get; set; }
        public int ShippingAdressId { get; set; }
        public string DateOfOrder { get; set; }
    }
}
