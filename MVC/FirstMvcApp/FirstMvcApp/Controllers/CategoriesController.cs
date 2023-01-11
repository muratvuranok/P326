using Microsoft.AspNetCore.Mvc;
namespace FirstMvcApp.Controllers;
public class CategoriesController : Controller
{
    public IActionResult Index() { return View(); }
    public IActionResult Create() { return View(); }
    public IActionResult Edit() { return View(); }
    public IActionResult Delete() { return View(); }
    public IActionResult Details() { return View(); }
}
