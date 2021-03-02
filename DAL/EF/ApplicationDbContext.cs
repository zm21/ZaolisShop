using DAL.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class ApplicationUser : IdentityUser
    {
        public virtual UserAdditionalInfo UserAdditionalInfo { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("zaolisShop", throwIfV1Schema: false)
        {
        }

        public DbSet<UserAdditionalInfo> UserAdditionalInfos { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInfo> ProductInfos { get; set; }
        public DbSet<ShippingAdress> ShippingAdresses { get; set; }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ShippingAdressConfig());
            modelBuilder.Configurations.Add(new UserInfoConfig());
        }
    }

    public class ShippingAdressConfig:EntityTypeConfiguration<ShippingAdress>
    {
        public ShippingAdressConfig()
        {
            this.HasRequired(u => u.UserAdditionalInfo).WithMany(s => s.ShippingAdresses).HasForeignKey(r => r.UserAdditionalInfoId).WillCascadeOnDelete(true); ;
        }
    }

    public class UserInfoConfig : EntityTypeConfiguration<UserAdditionalInfo>
    {
        public UserInfoConfig()
        {
            this.HasMany(u => u.ShippingAdresses).WithRequired(s => s.UserAdditionalInfo).WillCascadeOnDelete(true);
        }
    }

}
