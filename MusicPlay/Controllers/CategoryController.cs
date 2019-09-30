using MusicPlay.Repository;
using System.Web.Mvc;
using MusicPlay.Models;
using System.Collections.Generic;
using System;

namespace MusicPlay.Controllers
{
    public class CategoryController : Controller
    {

        private CategoryRepository categoryRepository = new CategoryRepository();

        // GET: Category
        public ActionResult Index()
        {
            List<Models.CategoryModel> list = categoryRepository.GetAll();
            return View();
        }

        // GET: Category/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                //instantierea modelului(clasei)
                CategoryModel categoryModel = new CategoryModel();

                //incarcam datele in model
                UpdateModel(categoryModel);

                //apelam resursa care salveaza datele
                categoryRepository.Insert(categoryModel);

                return View("Success");

            }
            catch
            {
                return View("Failed");
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(Guid id)
        {
            CategoryModel category = categoryRepository.GetById(id);

            return View("Edit", category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                var category = new CategoryModel();
                UpdateModel(category);
                categoryRepository.Update(category);

                return View("Success");
            }
            catch
            {
                return View("Failed");
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(Guid id)
        {
            CategoryModel category = categoryRepository.GetById(id);

            return View("Delete", category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                categoryRepository.Delete(id);

                return View("Success");
            }
            catch
            {
                return View();
            }
        }

        // GET: Settings/GetCategories
        [HttpGet]
        public ActionResult View(FormCollection collection)
        {
            List<CategoryModel> categories = categoryRepository.GetAll();
            return View("View", categories);
        }
    }
}
