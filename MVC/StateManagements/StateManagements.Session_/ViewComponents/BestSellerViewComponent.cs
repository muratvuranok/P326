using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace StateManagements.Session_.ViewComponents;
public class BestSellerViewComponent : ViewComponent
{

    private readonly StateManagementsContext _context;
    public BestSellerViewComponent(StateManagementsContext context)
    {
        this._context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    { 
        var category = await _context.Categories.Where(x => x.Id == 2)
            .Include(x => x.Products)
            .FirstOrDefaultAsync();

        return View(model: category.Products);
    }
} 