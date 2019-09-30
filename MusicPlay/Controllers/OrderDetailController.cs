using MusicPlay.Repository;
using System.Web.Mvc;
using MusicPlay.Models;

namespace MusicPlay.Controllers
{
    public class OrderDetailController : Controller
    {

        private OrderDetailRepository OrderDetailsRepository = new OrderDetailRepository();

        // GET: OrderDetails
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrderDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderDetails/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: OrderDetails/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {       // TODO: Add insert logic here

                //instantierea modelului(clasei)
                OrderDetailModel OrderDetailsModel = new OrderDetailModel();

                //incarcam datele in model
                UpdateModel(OrderDetailsModel);


                //apelam resursa care salveaza datele
                OrderDetailsRepository.Insert(OrderDetailsModel);

                //redirectionare index 
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateOrderDetails");
            }
        }

        // GET: OrderDetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderDetails/Edit/5
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

        // GET: OrderDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderDetails/Delete/5
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
