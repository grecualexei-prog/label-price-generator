namespace LabelPriceGenerator;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal? PromoPrice { get; set; }
    public string Unit { get; set; } = "buc";
    public string Barcode { get; set; } = string.Empty;
    public string? Notes { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
