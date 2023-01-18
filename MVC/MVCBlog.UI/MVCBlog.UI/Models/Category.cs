namespace MVCBlog.UI.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public virtual ICollection<Post>? Posts { get; set; }
}
/*
  CodeFirst Db Ekleme işlemi yapılacak 2 tablo Category, Post 
 
 */