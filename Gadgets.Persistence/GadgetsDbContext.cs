using Microsoft.EntityFrameworkCore;

namespace Gadgets.Persistence;

internal class GadgetsDbContext(DbContextOptions<GadgetsDbContext> options ) : DbContext(options)
{
}
