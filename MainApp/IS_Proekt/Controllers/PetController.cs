using Domain.PetStore;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;

namespace Web.Controllers
{
    public class PetController : Controller
    {
        private readonly IPetService _petService;
        public PetController(IPetService petService)
        {
            _petService = petService;
        }
        public IActionResult Index()
        {
            return View(_petService.GetAllAvaliablePets().ToList<Pet>());
        }
    }
}
