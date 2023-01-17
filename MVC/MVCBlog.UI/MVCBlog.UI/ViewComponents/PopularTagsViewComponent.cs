using Microsoft.AspNetCore.Mvc;
using MVCBlog.UI.Models;

namespace MVCBlog.UI.ViewComponents;


// Views/Shared/Components/PriorityList/Default.cshtml
public class PopularTagsViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var tags = new List<PopularTag>
        {
            new PopularTag { Id = 1, Name = "semper"},
            new PopularTag { Id = 2, Name = "ullamcorper"},
            new PopularTag { Id = 3, Name = "condimentum"},
            new PopularTag { Id = 4, Name = "semper"},
            new PopularTag { Id = 5, Name = "ullamcorper"},
            new PopularTag { Id = 6, Name = "condimentum"},
            new PopularTag { Id = 7, Name = "semper"},
            new PopularTag { Id = 8, Name = "ullamcorper"},
            new PopularTag { Id = 9, Name = "condimentum"}
        };

        return View(model: tags);
    }

}


















