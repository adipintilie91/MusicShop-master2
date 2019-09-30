using MusicPlay.Repository;
using System.Web.Mvc;
using MusicPlay.Models;
using System;
using System.Collections.Generic;

namespace MusicPlay.Controllers
{
    public class ProductDetailController : Controller
    {
        private ProductDetailRepository productDetailRepository = new ProductDetailRepository();
        private ProductRepository productRepository = new ProductRepository();
        private CountryRepository countryRepository = new CountryRepository();

        [HttpGet]
        public ActionResult View(FormCollection collection)
        {
            List<Models.ProductDetailModel> list = productDetailRepository.GetAll();
            return View("View", list);
        }

        // GET: InstrumentDetails
        public ActionResult Index()
        {
            List < Models.ProductDetailModel >list = productDetailRepository.GetAll();
            return View();
        }

        // GET: InstrumentDetails/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: InstrumentDetails/Create
        public ActionResult Create()
        {
            //incarca lista cu products si countries
            ViewData["products"] = productRepository.GetProductsList();

            ViewData["countries"] = countryRepository.GetCountriesList();

            return View("Create");
        }

        //load productdetails prin ajax
        [HttpGet]
        public ActionResult LoadProductDetails(Guid id)
        {
            ProductDetailRepository pdRepo = new ProductDetailRepository();

            return
            
            Json(pdRepo.GetProductDetailsByProduct(id), JsonRequestBehavior.AllowGet);//returneaza un json-lista de orase – prin GET
        }

        [HttpGet]
        public ActionResult LoadCountries(Guid id)
        {
            CountryRepository cRepo = new CountryRepository();

            return

            Json(cRepo.GetCountriesById(id), JsonRequestBehavior.AllowGet);//returneaza un json-lista de orase – prin GET
        }

        // POST: InstrumentDetails/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                ProductDetailModel productDetailModel = new ProductDetailModel();
                productDetailModel.CreationDate = DateTime.UtcNow;

                //incarca lista de products si countries
                ViewData["products"] = productRepository.GetProductsList();
                ViewData["countries"] = countryRepository.GetCountriesList();

                UpdateModel(productDetailModel);

                productDetailRepository.Insert(productDetailModel);

                return View("Success");
            }
            catch
            {
                return View("Failed");
            }
        }

        // GET: InstrumentDetails/Edit/5
        public ActionResult Edit(Guid id)
        {
     
            return View("Edit");
        }

        // POST: InstrumentDetails/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: InstrumentDetails/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View();
        }

        // POST: InstrumentDetails/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
