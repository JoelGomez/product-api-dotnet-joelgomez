namespace api_restfull_net8.Models

public class ProductCreateDto
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public bool Active { get; set; }
}
