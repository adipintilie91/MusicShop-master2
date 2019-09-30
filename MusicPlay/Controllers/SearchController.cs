using MusicPlay.Models;
using MusicPlay.Repository;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MusicPlay.Controllers
{
    public class SearchController : Controller
    {
        private ProductDetailRepository productDetailRepository = new ProductDetailRepository();

        //public ActionResult Index()
        //{
        //    ViewBag.Message = "search page";

        //    return View("Index");
        //}

        // GET: ProductDetails
        [HttpPost]
        public ActionResult Index(string productName)
        {
            List<ProductDetailModel> products = productDetailRepository.GetAll();

            if (!string.IsNullOrEmpty(productName))
            {
                products = products.Where(p => p.Name.Contains(productName)).ToList();
            }

            //if (!string.IsNullOrEmpty(productDescription))
            //{
            //    products = products.Where(p => p.Description == productDescription).ToList();
            //}

            var searchModel = new SearchModel
            {
                ProductDetails = new SelectList(products.OrderBy(x => x.Name).Distinct()),
            };

            return View(searchModel);
        }
    }
}