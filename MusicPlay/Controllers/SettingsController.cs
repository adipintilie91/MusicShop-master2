using MusicPlay.Models;
using MusicPlay.Repository;
using System.Web.Mvc;


namespace MusicPlay.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Settings
        public ActionResult Index()
        {
            return View();
        }

        // GET: Settings/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Settings/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // GET: Settings/Create
        public ActionResult Settings()
        {
            return View("Settings");
        }

        // GET: Settings/Edit/5
        public ActionResult Edit(int id)
        {
            //ProductRepository productModel = ProductRepository
            //CodeSnippetModel codeSnippetToEdit = codeSnippetRepository.GetCodeSnippetByID(id);

            return View();
        }

        // POST: Settings/Edit/5
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

        // GET: Settings/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Settings/Delete/5
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