using Microsoft.EntityFrameworkCore;

namespace azure_app_pp_rdr.Data;

public class AppDbContext : DbContext
{
    public DbSet<Person> Persons => Set<Person>();

    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }
}
