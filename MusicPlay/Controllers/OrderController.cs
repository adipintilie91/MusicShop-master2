﻿using MusicPlay.Repository;
using System.Web.Mvc;
using MusicPlay.Models;

namespace MusicPlay.Controllers
{
    public class OrderController : Controller
    {

        private OrderRepository OrderRepository = new OrderRepository();

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {       // TODO: Add insert logic here

                //instantierea modelului(clasei)
                OrderModel OrderModel = new OrderModel();

                //incarcam datele in model
                UpdateModel(OrderModel);


                //apelam resursa care salveaza datele
                OrderRepository.Insert(OrderModel);

                //redirectionare index 
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateOrder");
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
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

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
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
