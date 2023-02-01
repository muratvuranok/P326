using Microsoft.AspNetCore.Mvc;

namespace MVCDataTable.Controllers;

public class ECommerceController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
