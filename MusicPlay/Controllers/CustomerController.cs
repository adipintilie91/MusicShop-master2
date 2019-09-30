using MusicPlay.Repository;
using System.Web.Mvc;
using MusicPlay.Models;

namespace MusicPlay.Controllers
{
    public class CustomerController : Controller
    {

        private CustomerRepository CustomersRepository = new CustomerRepository();

        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {       // TODO: Add insert logic here

                //instantierea modelului(clasei)
                CustomerModel CustomersModel = new CustomerModel();

                //incarcam datele in model
                UpdateModel(CustomersModel);


                //apelam resursa care salveaza datele
                CustomersRepository.Insert(CustomersModel);

                //redirectionare index 
                return RedirectToAction("Index");
            }
            catch
            {
                return View("CreateCustomers");
            }
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customers/Edit/5
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

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customers/Delete/5
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
