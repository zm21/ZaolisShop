using DAL.EF;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using DTO.CreateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZaolisShop.Areas.Admin.Controllers
{
    public class AdminPanelController : Controller
    {
        private IUnitOfWork unitOfWork;

        public AdminPanelController()
        {
            unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult CategoryList()
        {
            var data = unitOfWork.CategoryRepository.Get();
            return View(data);
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(CategoryCreateDTO model)
        {
            unitOfWork.CategoryRepository.Create(new Category 
            {
                Name = model.Name
            });

            unitOfWork.Save();
            return RedirectToAction("Index", "Home");
        }
    }
}