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

       

    }
}