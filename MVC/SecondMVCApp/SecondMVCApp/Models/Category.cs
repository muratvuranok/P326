using System.ComponentModel.DataAnnotations;

namespace SecondMVCApp.Models;
public class Category
{
    [Display(Name = "Идентификатор категории")]
    public int CategoryID { get; set; }
      

    [Display(Name = "Название категории")]
    public string CategoryName { get; set; } = null!;

    [Display(Name = "Объяснение")]
    public string? Description { get; set; }
}
