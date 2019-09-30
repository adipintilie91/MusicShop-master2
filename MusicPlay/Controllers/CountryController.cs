using MusicPlay.Repository;
using System.Web.Mvc;
using MusicPlay.Models;
using System;
using System.Collections.Generic;

namespace MusicPlay.Controllers
{
    public class CountryController : Controller
    {

        private CountryRepository CountriesRepository = new CountryRepository();
        private ProductRepository productRepository = new ProductRepository();
        private CountryRepository countryRepository = new CountryRepository();

        // GET: Countries
        public ActionResult View()
        {
            List<Models.CountryModel> list = countryRepository.GetAll();
            return View("View", list);
        }
        public ActionResult Index()
        {
            List<Models.CountryModel> list = countryRepository.GetAll();
            return View("Index");
        }

        // GET: Countries/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Countries/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Countries/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                CountryModel countryModel = new CountryModel();

                UpdateModel(countryModel);

                return View("Success");
            }
            catch
            {
                return View("Failed");
            }
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Countries/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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

        // GET: Countries/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Countries/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
