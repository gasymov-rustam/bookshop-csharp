namespace BookShop.Domain.Entities;

public sealed class Author : BaseEntity
{
    public Author(
        string name,
        string lastName) : base()
    {
        Name = name;
        LastName = lastName;
    }

    public string Name { get; private set; }
    public string LastName { get; private set; }
}