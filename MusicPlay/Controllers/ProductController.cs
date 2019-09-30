using MusicPlay.Repository;
using System.Web.Mvc;
using MusicPlay.Models;
using System.Collections.Generic;
using System;

namespace MusicPlay.Controllers
{
    public class ProductController : Controller
    {

        private ProductRepository productRepository = new ProductRepository();
        private CategoryRepository categoryRepository = new CategoryRepository();

        // GET: Instruments
        public ActionResult Index()
        {

            List<Models.ProductModel> list = productRepository.GetAll();
            return View();
        }

        // GET: Instruments/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Instruments/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Instruments/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {       // TODO: Add insert logic here

                //instantierea modelului(clasei)
                ProductModel productModel = new ProductModel();
                //incarcam datele in model
                UpdateModel(productModel);

                var categoryByName = categoryRepository.GetByName(productModel.Categories.ToString());
                if(categoryByName != null)
                {
                    productModel.CategoryId = categoryByName.Id;
                    //apelam resursa care salveaza datele
                    productRepository.Insert(productModel);

                    //redirectionare index 
                    return View("Success");
                }

                return View("Failed");

            }
            catch
            {
                return View("Failed");
            }
        }

        // GET: Instruments/Edit/5
        public ActionResult Edit(Guid id)
        {
            ProductModel product = productRepository.GetById(id);

            return View("Edit", product);
        }

        // POST: Instruments/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                var product = new ProductModel();
                UpdateModel(product);
                productRepository.Update(product);

                return View("Success");
            }
            catch
            {
                return View("Failed");
            }
        }

        // GET: Instruments/Delete/5
        public ActionResult Delete(Guid id)
        {
            ProductModel product = productRepository.GetById(id);

            return View("Delete", product);

        }

        // POST: Instruments/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                productRepository.Delete(id);
                return View("Success");
            }
            catch
            {
                return View("Failed");
            }
        }

        // GET: Settings/GetCategories
        [HttpGet]
        public ActionResult View(FormCollection collection)
        {
            List<ProductModel> products = productRepository.GetAll();
            return View("View", products);
        }
    }
}
