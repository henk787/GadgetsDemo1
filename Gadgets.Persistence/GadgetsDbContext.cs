using Gadgets.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Gadgets.Persistence;

public class GadgetsDbContext(DbContextOptions<GadgetsDbContext> options, ILogger<GadgetsDbContext> logger ) : DbContext(options)
{

    public DbSet<Gadget> Gadgets { get; set; }



    // proof the pudding
    public override ValueTask DisposeAsync()
    {
        logger.LogInformation("DisposeAsync");
        return base.DisposeAsync();
    }

    public override void Dispose()
    {
        logger.LogInformation("Dispose");
        base.Dispose();
    }
}
