using KwetService.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace KwetService.Dal.Context;

public class KwetServiceContext : DbContext
{
    public DbSet<Kwet> Kwets { get; set; }

    public KwetServiceContext(DbContextOptions<KwetServiceContext> options) : base(options)
    {
        
    }
}