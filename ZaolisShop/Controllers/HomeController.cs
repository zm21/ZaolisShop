using DAL.EF;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Models;


namespace ZaolisShop.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork unitOfWork;
        private ApplicationDbContext _context;
        public HomeController()
        {
            _context = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(_context);
        }
        public ActionResult Index()
        {
            HomePageProductDTO model = new BLL.Models.HomePageProductDTO();
            var products = unitOfWork.ProductInfoRepository.Get();
            List<ProductInfDTO> productInfDTOs = new List<ProductInfDTO>();
            foreach (var item in products)
            {
                if(productInfDTOs.FirstOrDefault(p=>p.Id==item.ProductId)==null)
                {
                    var product = new ProductInfDTO
                    {
                        Id = item.ProductId,
                        Price = item.Product.Price,
                        Name = item.Product.Name
                    };
                    var Images = item.Images.ToList();
                    if(Images.Count>0 && Images.Count>=2)
                    {
                        product.Img1 = Images[0].Name;
                        product.Img2 = Images[1].Name;
                    }
                    productInfDTOs.Add(product);
                }
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}