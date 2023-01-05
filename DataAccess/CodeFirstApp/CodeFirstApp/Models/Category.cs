using System.ComponentModel.DataAnnotations;

namespace CodeFirstApp.Models;
public class Category
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; } = null!;
    [MaxLength(500)]
    public string? Description { get; set; }
}
