using Microsoft.EntityFrameworkCore;
using MVCBlog.UI.Models;

namespace MVCBlog.UI.Data;
public class MVCBlogDataContext : DbContext
{
    public MVCBlogDataContext(DbContextOptions<MVCBlogDataContext> options) : base(options) { }

    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
}