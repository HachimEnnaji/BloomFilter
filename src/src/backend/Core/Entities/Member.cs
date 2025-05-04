namespace BloomFilter.Core.Entities;

public class Member
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Surname { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;

    public Member(string name, string surname, string email)
    {
        Id = Guid.NewGuid();
        Name = name;
        Surname = surname;
        Email = email;
    }
    private Member(Guid id, string name, string surname, string email)
    {
        Id = id;
        Name = name;
        Surname = surname;
        Email = email;
    }

    public static Member Create(Guid id, string name, string surname, string email)
    {
        return new Member(id, name, surname, email);
    }
}
