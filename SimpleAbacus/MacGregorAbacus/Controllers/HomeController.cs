using System.Web.Mvc;
using MacGregorAbacus.Models;

namespace MacGregorAbacus.Controllers
{
    // Controllers for the home page
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var abacusView = new AbacusViewModel();

            return View(abacusView);
        }

        [HttpPost]
        public ActionResult RunAbacus(AbacusViewModel abacusView)
        {
            if (ModelState.IsValid)
            {
                var abacusModel = new AbacusDomainModel(abacusView.FirstNumber, abacusView.SecondNumber);

                abacusView.ResultNumber = abacusModel.ResultNumber.ToString();

                return View("Index", abacusView);
            }
            else
            {
                return View("Index", abacusView);
            }
            
        }

        
    }
}