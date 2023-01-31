using Microsoft.EntityFrameworkCore;
using SignalRProject.Models;

namespace SignalRProject.Data;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }
    public virtual DbSet<Category> Categories { get; set; } = null!;
}

