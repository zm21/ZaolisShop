using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ShippingAdressDTO
    {

        public int Id { get; set; }

        public string City { get; set; }

        public string Adress { get; set; }

        public int Appartment { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public string PostalCode { get; set; }

        public string Phone { get; set; }

        public string UserAdditionalInfoId { get; set; }
    }
}
