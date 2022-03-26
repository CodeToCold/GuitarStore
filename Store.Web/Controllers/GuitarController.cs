using Microsoft.AspNetCore.Mvc;

namespace Store.Web.Controllers
{
    public class GuitarController : Controller
    {
        private readonly IGuitarRepository guitarRepository;

        public GuitarController(IGuitarRepository guitarRepository)
        {
            this.guitarRepository = guitarRepository;
        }

        public IActionResult Index(int id)
        {
            Guitar guitar = guitarRepository.GetById(id);

            return View(guitar);
        }
    }
}
