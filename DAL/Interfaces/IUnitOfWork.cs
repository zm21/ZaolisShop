using DAL.EF;
using DAL.Entities;
using System;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<ApplicationUser> ApplicationUserRepository { get; }
        
        IGenericRepository<Cart> CartRepository { get; }

        IGenericRepository<Category> CategoryRepository { get; }

        IGenericRepository<Image> ImageRepository { get; }

        IGenericRepository<Order> OrderRepository { get; }

        IGenericRepository<Product> ProductRepository { get; }

        IGenericRepository<ProductInfo> ProductInfoRepository { get; }

        IGenericRepository<ShippingAdress> ShippingAdressRepository { get; }

        IGenericRepository<UserAdditionalInfo> UserAdditionalInfoRepository { get; }

        void Save();
    }
}
