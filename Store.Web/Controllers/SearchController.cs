using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly GuitarService guitarService;     
        
        public SearchController(GuitarService guitarService)
        {
            this.guitarService = guitarService;        
        }
        
        public IActionResult Index(string query)
        {
            var guitars = guitarService.GetAllByQuery(query);

                return View(guitars);
        }
    }
}
