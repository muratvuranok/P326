﻿namespace StateManagements.Session_.Models;
public class Cart
{
    public int Id { get; set; } 
    public decimal? Price { get; set; }
    public string? Name { get; set; }
    public string? CartImage { get; set; }
    public byte? Count { get; set; } = 1;
    public decimal? Total => this.Count * this.Price; 
}
