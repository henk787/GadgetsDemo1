using Microsoft.EntityFrameworkCore;
using Gadgets.Domain;

namespace Gadgets.Persistence;

public class GadgetsDbContext(DbContextOptions<GadgetsDbContext> options ) : DbContext(options)
{

    public DbSet<Gadget> Gadgets { get; set; }
}
