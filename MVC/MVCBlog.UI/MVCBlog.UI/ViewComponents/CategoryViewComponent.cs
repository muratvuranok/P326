using Microsoft.AspNetCore.Mvc;
using MVCBlog.UI.Models;

namespace MVCBlog.UI.ViewComponents;

public class CategoryViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories = new List<Category>
        {
            new Category { Id = 1, Name = "Vestibulum tincidunt"},
            new Category { Id = 1, Name = "Aliquam ullamcor dolor"},
            new Category { Id = 1, Name = "Quisque nec lobortis"},
            new Category { Id = 1, Name = "Maecenas rutrum nunc"},
            new Category { Id = 1, Name = "Eliquam faucibus"},
            new Category { Id = 1, Name = "Aenean sollicitudin eros"}
        };
        return View(model: categories);
    }
}


















