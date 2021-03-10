using BLL.CreateModels;
using BLL.Models;
using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System.Linq;
using System.Web.Mvc;

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
                Name=model.Name
            });
            _context.SaveChanges();
            return RedirectToAction("CategoryList", "AdminPanel");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var editCat = _context.Categories.Select(s => new CategoryDTO
            {
               Id=s.Id, 
               Name=s.Name
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
                Description=model.Description,
                Price=model.Price,
                CategoryId = category.Id
            });
            _context.SaveChanges();
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
        public ActionResult CreateProductInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProductInfo(ProductInfoCreateDTO model)
        {
            _context.ProductInfos.Add(new DAL.Entities.ProductInfo
            {
                Color=model.Color,
                Count=model.Count,
                ProductId=model.ProductId,
                Size=model.Size
            });
            _context.SaveChanges();
            return RedirectToAction("Dashboard", "AdminPanel");
        }
    }
}