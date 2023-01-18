namespace MVCBlog.UI.Models;

public class Post
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public string? Content { get; set; }


    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}