namespace BookShop.Domain.Entities;

public sealed class Department : BaseEntity
{
    private List<Book> _books = new();

    public Department(
        string name) : base()
    {
        Name = name;
    }

    public string Name { get; private set; }

    public IReadOnlyCollection<Book> Books => _books;
}
