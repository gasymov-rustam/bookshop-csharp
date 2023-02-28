namespace BookShop.Domain.Entities;

public sealed class Book : BaseEntity
{
    public Book(
        string name,
        string description,
        int pages,
        decimal price) : base()
    {
        Name = name;
        Description = description;
        Pages = pages;
        Price = price;
    }

    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Pages { get; private set; }
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; private set; }

    public Guid AuthorId { get; private set; }
    public Author Author { get; set; }
    public Guid DepartmentId { get; set; }
    public Department Department { get; set; }
}