using Microsoft.AspNetCore.Mvc;
using SecondMVCApp.Models;


namespace SecondMVCApp.Controllers;

public class CategoriesController : Controller
{

    #region Data
    List<Category> categories = new List<Category>
    {
        new Category { CategoryID = 1 ,CategoryName = "Beverages" ,        Description = "Yeni Açiklama"},
        new Category { CategoryID = 2 ,CategoryName = "Condiments" ,       Description = "Sweet and savory sauces, relishes, spreads, and seasonings"},
        new Category { CategoryID = 3 ,CategoryName = "Confections" ,      Description = "Desserts, candies, and sweet breads"},
        new Category { CategoryID = 4 ,CategoryName = "Dairy Products" ,   Description = "Cheeses"},
        new Category { CategoryID = 5 ,CategoryName = "Grains/Cereals" ,   Description = "Breads, crackers, pasta, and cereal"},
        new Category { CategoryID = 6 ,CategoryName = "Meat/Poultry" ,     Description = "Prepared meats"},
        new Category { CategoryID = 7 ,CategoryName = "Produce" ,          Description = "Dried fruit and bean curd"},
        new Category { CategoryID = 8 ,CategoryName = "Seafood" ,          Description = "Seaweed and fish"},
    };
    #endregion

    public IActionResult Index()
    {

        ViewData["KategoriAdi"] = "Kategori Adı Bu Alan İçerisinde Yer Alacak";

        TempData["KategoriAciklama"] = "Kategori açıklamasınıda burdan gönderdim";

        ViewBag.CV1 = categories;
        ViewData["CV2"] = categories;
        TempData["CV3"] = categories;

        ViewData["V1"] = "V1";
        TempData["T2"] = "T2";

        var kategoriler = categories;  // database üzerinden dataları çektik :)
        return View(model: kategoriler);
    }



    public IActionResult Create()
    {
        return View();
    }
}
