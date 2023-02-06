namespace MVCDataTable.Models;
public class Cart
{
    public string Image { get; set; }
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public string ProductName { get; set; }
    public short Count { get; set; } = 1; 
    public decimal? Total => this.Price * this.Count;
}