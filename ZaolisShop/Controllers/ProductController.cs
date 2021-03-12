using DAL.EF;
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

            var viewPageProduct = viewProducts.Select(t => new ProductPageDTO()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description
            });


            if (viewPageProduct != null)
            {
                return View(viewPageProduct);
            }
            else
                return RedirectToAction("Index", "Home");
        }

    }
}