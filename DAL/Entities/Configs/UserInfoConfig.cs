using DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DAL.EF
{
    public class UserInfoConfig : EntityTypeConfiguration<UserAdditionalInfo>
    {
        public UserInfoConfig()
        {
            this.HasMany(u => u.ShippingAdresses).WithRequired(s => s.UserAdditionalInfo).WillCascadeOnDelete(true);
        }
    }

}
