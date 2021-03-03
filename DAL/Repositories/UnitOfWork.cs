using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using System;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext context;
        private IGenericRepository<ApplicationUser> applicationUserRepository;
        private IGenericRepository<Cart> cartRepository;
        private IGenericRepository<Category> categoryRepository;
        private IGenericRepository<Image> imageRepository;
        private IGenericRepository<Order> orderRepository;
        private IGenericRepository<Product> productRepository;
        private IGenericRepository<ProductInfo> productInfoRepository;
        private IGenericRepository<ShippingAdress> shippingAdressRepository;
        private IGenericRepository<UserAdditionalInfo> userAdditionalInfoRepository;

        private bool disposed = false;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IGenericRepository<ApplicationUser> ApplicationUserRepository
        {
            get
            {
                if (applicationUserRepository == null)
                    applicationUserRepository = new GenericRepository<ApplicationUser>(context);
                return applicationUserRepository;
            }
        }

        public IGenericRepository<Cart> CartRepository
        {
            get
            {
                if (cartRepository == null)
                    cartRepository = new GenericRepository<Cart>(context);
                return cartRepository;
            }
        }

        public IGenericRepository<Category> CategoryRepository
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new GenericRepository<Category>(context);
                return categoryRepository;
            }
        }

        public IGenericRepository<Image> ImageRepository
        {
            get
            {
                if (imageRepository == null)
                    imageRepository = new GenericRepository<Image>(context);
                return imageRepository;
            }
        }


        public IGenericRepository<Order> OrderRepository
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new GenericRepository<Order>(context);
                return orderRepository;
            }
        }

        public IGenericRepository<Product> ProductRepository
        {
            get
            {
                if (productRepository == null)
                    productRepository = new GenericRepository<Product>(context);
                return productRepository;
            }
        }

        public IGenericRepository<ProductInfo> ProductInfoRepository
        {
            get
            {
                if (productInfoRepository == null)
                    productInfoRepository = new GenericRepository<ProductInfo>(context);
                return productInfoRepository;
            }
        }

        public IGenericRepository<ShippingAdress> ShippingAdressRepository
        {
            get
            {
                if (shippingAdressRepository == null)
                    shippingAdressRepository = new GenericRepository<ShippingAdress>(context);
                return shippingAdressRepository;
            }
        }

        public IGenericRepository<UserAdditionalInfo> UserAdditionalInfoRepository
        {
            get
            {
                if (userAdditionalInfoRepository == null)
                    userAdditionalInfoRepository = new GenericRepository<UserAdditionalInfo>(context);
                return userAdditionalInfoRepository;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
