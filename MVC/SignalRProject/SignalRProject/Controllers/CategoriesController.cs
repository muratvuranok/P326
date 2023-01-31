using Microsoft.AspNetCore.Mvc;
using SignalRProject.Repositories;

namespace SignalRProject.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCategories()
        {
           var categories = await _categoryRepository.GetAll();
            //await _categoryRepository.Create(new());
            return Ok( categories);
        }
    }
}
