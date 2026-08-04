namespace RestaurantsApi.Models;

public class Restaurant
{
    public string Id { get; set; } = null!;
    public string Name { get; set; } = "";
    public string Cuisine { get; set; } = "";
    public double Rating { get; set; }
}