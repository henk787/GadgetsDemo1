using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gadgets.Domain;
using Gadgets.Persistence;
using Mediator;
using Microsoft.EntityFrameworkCore;

namespace Gadgets.Services.Queries
{
    public record  GetAllGadgetsQuery() : IQuery<Gadget[]>;


    internal class GetAllGadgetsQueryHandler(GadgetsDbContext gadgetsDbContext) : IQueryHandler<GetAllGadgetsQuery, Gadget[]>
    {
        public async ValueTask<Gadget[]> Handle(GetAllGadgetsQuery query, CancellationToken cancellationToken)
        {
            return await gadgetsDbContext
                .Gadgets
                .AsNoTracking()
                .ToArrayAsync(cancellationToken);
        }
    }
}
