using System.ComponentModel.DataAnnotations;
namespace MVCDataTrasferToAction.Models;

public class Category
{
    [Key] // primary key olarak işaretler
    public int CategoryID { get; set; }
    public string CategoryName { get; set; } = null!;
    public string? Description { get; set; }
}
