using BLL.Models;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZaolisShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private IUnitOfWork unitOfWork;
        private ApplicationDbContext _context;
        public ProductController()
        {
            _context = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(_context);
        }
        public ActionResult Details(int id)
        {
            var viewProducts = unitOfWork.ProductInfoRepository.Get(t => t.ProductId == id);
            var product = unitOfWork.ProductRepository.GetById(id);

            var viewPageProduct = new ProductPageDTO()
            {
                Name = product.Name,
                Id = product.Id,
                Price = product.Price,
                Description = product.Description
            };

            viewPageProduct.Colors = viewProducts.Select(t => t.Color).ToList();
            viewPageProduct.Sizes = viewProducts.Select(t => t.Size).ToList();

            var productinfos = new List<ProductInfo>();
            foreach (var item in viewProducts)
            {
                if (!productinfos.Select(t => t.Color).Contains(item.Color))
                {
                    productinfos.Add(item);
                }
            }

            var images = productinfos.Select(t => t.Images);
            var imageNames = new List<string>();

            foreach (var item in images)
            {
                imageNames.AddRange(item.Select(t => t.Name));
            }

            viewPageProduct.Images = imageNames;

            if (viewPageProduct != null)
            {
                return View(viewPageProduct);
            }
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Cart()
        {
            var user = unitOfWork.ApplicationUserRepository.Get(u => u.Email == User.Identity.Name)?.First();
            var cart = unitOfWork.CartRepository.Get(c => c.UserAdditionalInfoId == user.Id)?.FirstOrDefault();
            List<CartItemDTO> cartItems = new List<CartItemDTO>();
            if (cart != null)
            {
                foreach (var item in cart.CartItems)
                {
                    CartItemDTO cartItem = new CartItemDTO
                    {
                        Id = item.Id,
                        ProductInfoId = item.ProductInfoId,
                        Name = item.ProductInfo.Product.Name,
                        Price = item.ProductInfo.Product.Price,
                        Count = item.Count
                    };

                    cartItem.Image = item.ProductInfo.Images?.First()?.Name;
                    cartItems.Add(cartItem);
                }
            }
            return View(cartItems);
        }

        [Authorize]
        public ActionResult AddToCart(int id, string color, string size)
        {
            var user = unitOfWork.ApplicationUserRepository.Get(u => u.Email == User.Identity.Name)?.First();
            var cart = unitOfWork.CartRepository.Get(c => c.UserAdditionalInfoId == user.Id)?.FirstOrDefault();
            var product = unitOfWork.ProductRepository.GetById(id);
            var productInfo = product.ProductInfos.Where(t => t.Color == color && t.Size == size).FirstOrDefault();

            if (productInfo != null)
            {
                var cartItem = new CartItemDTO()
                {
                    Name = product.Name,
                    Price = product.Price,
                    Image = productInfo.Images.FirstOrDefault()?.Name,
                    Count = 1,
                    ProductInfoId = productInfo.Id
                };
                return RedirectToAction("Cart", "Product");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }
    }
}