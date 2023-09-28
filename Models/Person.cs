namespace CustomerApi.Models;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Age { get; set; }
    public decimal Discount { get; set; }
    public bool HasDiscount { get; set; }
    public string Type { get; set; } = string.Empty;
}
