using Microsoft.AspNetCore.Mvc;

namespace MVCDataTable.Controllers
{
    public class TestController : Controller
    {

        public const string SessionKeyName = "_Name";
        public const string SessionKeyAge = "_Age";
        public const string SessionKeyDate = "_Date";


        public IActionResult Index()
        {

            DateTime dt = DateTime.Now;

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyName)))
            {
                HttpContext.Session.SetString(SessionKeyName, "The Doctor");
                HttpContext.Session.SetInt32(SessionKeyAge, 73);
                HttpContext.Session.SetString(SessionKeyDate, dt.ToLongTimeString());
            }
            var name = HttpContext.Session.GetString(SessionKeyName);
            var age = HttpContext.Session.GetInt32(SessionKeyAge).ToString();
            var date = HttpContext.Session.GetString(SessionKeyDate);


            
            return Json(new
            {
                Name = name,
                Age = age,
                Cache_Date = date,
                Now = dt.ToLongTimeString()
            });
        }
    }
}
