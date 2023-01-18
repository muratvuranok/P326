using Microsoft.AspNetCore.Mvc;
using MVCBlog.UI.Data;

namespace MVCBlog.UI.ViewComponents;

public class CategoryViewComponent : ViewComponent
{
    MVCBlogDataContext _context;
    public CategoryViewComponent(MVCBlogDataContext context)
    {
        this._context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        #region Old
        //var categories = new List<Category>
        //{
        //    new Category {  Name = "Vestibulum tincidunt"},
        //    new Category {  Name = "Aliquam ullamcor dolor"},
        //    new Category {  Name = "Quisque nec lobortis"},
        //    new Category {  Name = "Maecenas rutrum nunc"},
        //    new Category {  Name = "Eliquam faucibus"},
        //    new Category {  Name = "Aenean sollicitudin eros"}
        //};


        //if (!_context.Categories.Any())
        //{
        //    _context.Categories.AddRange(categories);
        //    _context.SaveChanges();
        //} 
        #endregion
         
        var categories = _context.Categories.ToList();
        return View(model: categories);
    }
}


















