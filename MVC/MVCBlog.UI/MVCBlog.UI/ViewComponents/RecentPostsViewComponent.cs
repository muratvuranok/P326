using Microsoft.AspNetCore.Mvc;
using MVCBlog.UI.Models;

namespace MVCBlog.UI.ViewComponents;

public class RecentPostsViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {

        var posts = new List<Post>
        {
            new Post{ Id = 1, Name = "Fıstıklı Baklava", ImageUrl = "https://baklover.com/Contents/img/dolama-1.jpg", Content = "Fıstıklı Baklava"},
            new Post{ Id = 1, Name = "Fıstıklı Baklava", ImageUrl = "https://baklover.com/Contents/img/dolama-1.jpg", Content = "Fıstıklı Baklava"},
            new Post{ Id = 1, Name = "Fıstıklı Baklava", ImageUrl = "https://baklover.com/Contents/img/dolama-1.jpg", Content = "Fıstıklı Baklava"},
            new Post{ Id = 1, Name = "Fıstıklı Baklava", ImageUrl = "https://baklover.com/Contents/img/dolama-1.jpg", Content = "Fıstıklı Baklava"},
            new Post{ Id = 1, Name = "Fıstıklı Baklava", ImageUrl = "https://baklover.com/Contents/img/dolama-1.jpg", Content = "Fıstıklı Baklava"},
            new Post{ Id = 1, Name = "Fıstıklı Baklava", ImageUrl = "https://baklover.com/Contents/img/dolama-1.jpg", Content = "Fıstıklı Baklava"},
            new Post{ Id = 1, Name = "Fıstıklı Baklava", ImageUrl = "https://baklover.com/Contents/img/dolama-1.jpg", Content = "Fıstıklı Baklava"},
            new Post{ Id = 1, Name = "Fıstıklı Baklava", ImageUrl = "https://baklover.com/Contents/img/dolama-1.jpg", Content = "Fıstıklı Baklava"},
            new Post{ Id = 1, Name = "Fıstıklı Baklava", ImageUrl = "https://baklover.com/Contents/img/dolama-1.jpg", Content = "Fıstıklı Baklava"},
            new Post{ Id = 1, Name = "Fıstıklı Baklava", ImageUrl = "https://baklover.com/Contents/img/dolama-1.jpg", Content = "Fıstıklı Baklava"},
            new Post{ Id = 1, Name = "Fıstıklı Baklava", ImageUrl = "https://baklover.com/Contents/img/dolama-1.jpg", Content = "Fıstıklı Baklava"},
            new Post{ Id = 1, Name = "Fıstıklı Baklava", ImageUrl = "https://baklover.com/Contents/img/dolama-1.jpg", Content = "Fıstıklı Baklava"}
        };
        return View(model: posts);
    }
}


















