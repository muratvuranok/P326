using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace MVCDataTrasferToAction.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Title { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string? Genre { get; set; }
    [Precision(12, 8)]
    public decimal Price { get; set; }
}
