using Microsoft.EntityFrameworkCore;

namespace Glossary_API;

public class GlossaryDbContext : DbContext
{
    public GlossaryDbContext(DbContextOptions options) : base(options)
    {
    }
    public GlossaryDbContext()
    {
        
    }
    public DbSet<Term> Terms { get; set; }
    public DbSet<Definition> Definitions { get; set; }

}
