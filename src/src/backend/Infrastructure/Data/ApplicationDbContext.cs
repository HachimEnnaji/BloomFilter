using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BloomFilter.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{

    public DbSet<MemberEntity> Member { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
public class MemberEntity
{
    [Key]
    public Guid IdMember { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
}

