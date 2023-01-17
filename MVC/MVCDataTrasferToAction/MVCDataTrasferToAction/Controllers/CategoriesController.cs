using Microsoft.AspNetCore.Mvc;
using MVCDataTrasferToAction.Models;

namespace MVCDataTrasferToAction.Controllers;
public class CategoriesController : Controller
{

    public ActionResult Index()
    {

        return View();
    }


    [HttpGet]  //  yazmanıza gerek yoktur, default olarak get metodu çalışır
    public ActionResult Create()
    {

        return View();
    }

    [HttpPost]
    public ActionResult Create(Category category)
    {

        return View();
    }






    //public IActionResult Create(Category category)
    //{

    //    bool result = HttpContext.Request.Method == "POST";

    //    if (result)
    //    {
    //        return RedirectToAction("index", "home");
    //    }
    //    else
    //    {

    //    }


    //    return View();
    //}

}
