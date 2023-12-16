using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Repository.EfCore;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    public DbSet<Developer> Developers { get; set; }
    public DbSet<Project> Projects { get; set; }
}
