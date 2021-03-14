using BLL.CreateModels;
using BLL.Models;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using DTO.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZaolisShop.Helper;

namespace ZaolisShop.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        private ApplicationDbContext _context;

        private IUnitOfWork unitOfWork;

        public AdminPanelController()
        {

            _context = new ApplicationDbContext();
            unitOfWork = new UnitOfWork(_context);

            unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        public ActionResult Dashboard()
        {
            return View();
        }


        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(CategoryCreateDTO model)
        {
            _context.Categories.Add(new DAL.Entities.Category
            {
                Name = model.Name
            });
            _context.SaveChanges();
            return RedirectToAction("CategoryList", "AdminPanel");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var editCat = _context.Categories.Select(s => new CategoryDTO
            {
                Id = s.Id,
                Name = s.Name
            }).FirstOrDefault(s => s.Id == id);

            if (editCat != null)
            {
                return View(editCat);
            }
            else
                return RedirectToAction("CategoryList", "AdminPanel");

        }
        [HttpPost]
        public ActionResult EditCategory(CategoryDTO model)
        {
            var editCat = _context.Categories.FirstOrDefault(t => t.Id == model.Id);
            if (editCat != null)
            {
                editCat.Name = model.Name;
                _context.SaveChanges();
                return RedirectToAction("CategoryList", "AdminPanel");
            }
            return RedirectToAction("CategoryList", "AdminPanel");
        }


        public ActionResult CategoryList()
        {
            var data = unitOfWork.CategoryRepository.Get().Select(c => new CategoryDTO
            {
                Id = c.Id,
                Name = c.Name
            });
            return View(data);
        }


        [HttpGet]
        public ActionResult CreateProduct()
        {
            var model = new ProductCreateDTO();
            model.Categories.AddRange(
                unitOfWork.CategoryRepository.Get().Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }));
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductCreateDTO model)
        {
            var category = unitOfWork.CategoryRepository.GetById(int.Parse(model.CategoryId));
            _context.Products.Add(new DAL.Entities.Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                CategoryId = category.Id
            });
            _context.SaveChanges();
            return RedirectToAction("ProductList", "AdminPanel");
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            var editProd = _context.Products.Select(s => new EditProductDTO
            {
                Id = s.Id,
                CategoryId = s.CategoryId.ToString(),
                Description = s.Description,
                Name = s.Name,
                Price = s.Price
            }).FirstOrDefault(s => s.Id == id);
            editProd.Categories.AddRange(
                unitOfWork.CategoryRepository.Get().Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() }));
            if (editProd != null)
            {
                return View(editProd);
            }
            else
                return RedirectToAction("ProductList", "AdminPanel");

        }
        [HttpPost]
        public ActionResult EditProduct(EditProductDTO model)
        {
            var editProd = _context.Products.FirstOrDefault(t => t.Id == model.Id);
            if (editProd != null)
            {
                editProd.Price = model.Price;
                editProd.Name = model.Name;
                editProd.Description = model.Description;
                editProd.CategoryId = int.Parse(model.CategoryId);
                _context.SaveChanges();
                return RedirectToAction("ProductList", "AdminPanel");
            }
            return RedirectToAction("ProductList", "AdminPanel");
        }

        public ActionResult ProductList()
        {
            var data = unitOfWork.ProductRepository.Get().Select(c => new ProductDTO
            {
                Id = c.Id,
                Name = c.Name,
                Price = c.Price,
                Category = c.Category.Name,
                CategoryId = c.CategoryId,
                Description = c.Description
            });


            return View(data);
        }


        [HttpGet]
        public ActionResult CreateProductInfo(int id)
        {
            var product = unitOfWork.ProductRepository.GetById(id);
            if (product != null)
            {
                ProductInfoCreateDTO model = new ProductInfoCreateDTO();
                model.ProductId = id;
                return View(model);
            }
            return RedirectToAction("ProductList", "AdminPanel");
        }

        [HttpPost]
        public ActionResult CreateProductInfo(ProductInfoCreateDTO model, HttpPostedFileBase Img1, HttpPostedFileBase Img2)
        {
            var product = unitOfWork.ProductRepository.GetById(model.ProductId);
            if (product != null)
            {
                string fileName1 = Guid.NewGuid().ToString() + ".jpg";
                string fileName2 = Guid.NewGuid().ToString() + ".jpg";
                string image1 = Server.MapPath(Constants.ImageProductPath) + fileName1;
                string image2 = Server.MapPath(Constants.ImageProductPath) + fileName2;
                var enumDisplaySize = (SIZE)model.Size;
                var productInfo = new ProductInfo
                {
                    Color = model.Color,
                    Count = model.Count,
                    ProductId = model.ProductId,
                    Size = enumDisplaySize.ToString()
                };

                unitOfWork.ProductInfoRepository.Create(productInfo);
                unitOfWork.Save();
                using (Bitmap img = new Bitmap(Img1.InputStream))
                {
                    Bitmap saveImg = ImageWorker.CreateImage(img, 470, 705);
                    if (saveImg != null)
                    {
                        saveImg.Save(image1, ImageFormat.Jpeg);

                        unitOfWork.ImageRepository.Create(new DAL.Entities.Image { Name = fileName1, ProductInfoId = productInfo.Id });
                        unitOfWork.Save();
                    }
                }
                using (Bitmap img = new Bitmap(Img2.InputStream))
                {
                    Bitmap saveImg = ImageWorker.CreateImage(img, 470, 705);
                    if (saveImg != null)
                    {
                        saveImg.Save(image2, ImageFormat.Jpeg);

                        unitOfWork.ImageRepository.Create(new DAL.Entities.Image { Name = fileName2, ProductInfoId = productInfo.Id });
                        unitOfWork.Save();
                    }
                }
            }
            return RedirectToAction("Dashboard", "AdminPanel");
        }

        public ActionResult ProductInfoList(int id)
        {
            List<ProductInfoDTO> productInfos = new List<ProductInfoDTO>();
            foreach (var item in unitOfWork.ProductInfoRepository.Get(p=>p.ProductId == id))
            {
                var images = item.Images.Select(i => i.Name).ToList();
                ProductInfoDTO productInfo = new ProductInfoDTO
                {
                    Id = item.Id,
                    Color = item.Color,
                    Count = item.Count,
                    ProductId = item.ProductId,
                    ProductName = item.Product.Name,
                    Size = item.Size
                };
                if(images.Count>0)
                {
                    productInfo.Img1 = images.First();
                }
                productInfos.Add(productInfo);
            }

            return View(productInfos);
        }

        [HttpGet]
        public ActionResult EditProductInfo(int id)
        {
            var editProd = _context.ProductInfos.Select(s => new ProductInfoDTO
            {
                Id = s.Id,
                Color = s.Color,
                Count = s.Count,
                Size = s.Size,
                ProductName = s.Product.Name
            }).FirstOrDefault(s => s.Id == id);

            if (editProd != null)
            {
                return View(editProd);
            }
            else
                return RedirectToAction("ProductList", "AdminPanel");

        }
        [HttpPost]
        public ActionResult EditProductInfo(ProductInfoDTO model)
        {
            var editProd = _context.ProductInfos.FirstOrDefault(t => t.Id == model.Id);
            if (editProd != null)
            {
                editProd.Product.Name = model.ProductName;
                editProd.Color = model.Color;
                editProd.Count = model.Count;
                editProd.Size = model.Size;
                _context.SaveChanges();
                return RedirectToAction("ProductList", "AdminPanel");
            }
            return RedirectToAction("ProductList", "AdminPanel");
        }


        public ActionResult UsersList()
        {
            var data = unitOfWork.ApplicationUserRepository.Get().Select(c => new ApplicationUserDTO
            {
                Id = c.Id,
                Email=c.Email,
                PhoneNumber=c.PhoneNumber,
                FullName = c?.UserAdditionalInfo?.FirstName + " " + c?.UserAdditionalInfo?.LastName 
            });
            return View(data);
        }

        public ActionResult UserOrdersList(string userId)
        {
            var data = unitOfWork.OrderRepository.Get().Where(o=>o.UserAdditionalInfoId==userId).Select(c => new OrderDTO
            {
                Id = c.Id,
                DateOfOrder=c.DateOfOrder,
                ShippingAdress=c.UserAdditionalInfo.ShippingAdresses.FirstOrDefault().ToString()
            });
            return View(data);
        }

        public ActionResult ShowShippingAdress(int id)
        {
            var order = unitOfWork.OrderRepository.GetById(id);
            var c = order.ShippingAdress;
            var data = new ShippingAdressDTO
            {
                Id = c.Id,
                Adress=c.Adress,
                FirstName=c.FirstName,
                Appartment=c.Appartment,
                City=c.City,
                Country=c.Country,
                LastName=c.LastName,
                Phone=c.Phone,
                PostalCode=c.PostalCode
            };
            return View(data);
        }

        public ActionResult ShowProduct(int id)
        {
            var order = unitOfWork.OrderRepository.GetById(id);
            var data = unitOfWork.ProductRepository.Get().Where(pr=>pr.Orders.Contains(order)).Select(c => new ProductDTO
            {
                Id = c.Id,
                Category=c.Category.Name,
                Description=c.Description,
                Name=c.Name,
                Price=c.Price
            });
            return View(data);
        }
    }
}