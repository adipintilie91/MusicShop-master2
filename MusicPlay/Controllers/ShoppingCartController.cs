using MusicPlay.Repository;
using System.Web.Mvc;
using MusicPlay.Models;
using System.Collections.Generic;
using System;

namespace MusicPlay.Controllers
{
    public class ShoppingCartController : Controller
    {

        private OrderRepository orderRepository = new OrderRepository();
        private OrderDetailRepository orderDetailsRepository = new OrderDetailRepository();

        // GET: Category
        public ActionResult Index()
        {
            List<OrderModel> orders = orderRepository.GetAll();
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
                OrderModel order = new OrderModel();
                OrderDetailModel orderDetails = new OrderDetailModel();

                //incarcam datele in model
                UpdateModel(order);
                UpdateModel(orderDetails);

                //apelam resursa care salveaza datele
                orderRepository.Insert(order);
                orderDetailsRepository.Insert(orderDetails);

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
            OrderModel order = orderRepository.GetById(id);
            //OrderDetailModel orderDetails = orderDetailsRepository.GetById(id);

            return View("Edit", order);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, FormCollection collection)
        {
            try
            {
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
            OrderModel order = orderRepository.GetById(id);
            //OrderDetailModel orderDetails = orderDetailsRepository.GetById(id);

            return View("Delete", order);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                orderRepository.Delete(id);

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
            List<OrderModel> orders = orderRepository.GetAll();
            List<OrderDetailModel> orderDetails = orderDetailsRepository.GetAll();
            List<ShoppingCartModel> shoppingCarts = new List<ShoppingCartModel>()
            {
                new ShoppingCartModel()
                {
                     Orders = orders,
                     OrderDetails = orderDetails
                }
            };

            return View("View", shoppingCarts);
        }
    }
}
