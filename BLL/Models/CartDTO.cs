using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace DAL.Entities
{
    [DataContract]
    public class Cart
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public virtual ICollection<Product> Products { get; set; }

        [DataMember]
        public string UserAdditionalInfoId { get; set; }

    }
}
