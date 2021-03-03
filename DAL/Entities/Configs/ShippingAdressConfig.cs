using DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DAL.EF
{
    public class ShippingAdressConfig:EntityTypeConfiguration<ShippingAdress>
    {
        public ShippingAdressConfig()
        {
            this.HasRequired(u => u.UserAdditionalInfo).WithMany(s => s.ShippingAdresses).HasForeignKey(r => r.UserAdditionalInfoId).WillCascadeOnDelete(true); ;
        }
    }

}
