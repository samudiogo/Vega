using System.Threading.Tasks;
using Vega.Domain.Interfaces;
using Vega.Infra.Data.Context;

namespace Vega.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VegaDbContext _context;

        public UnitOfWork(VegaDbContext context) => _context = context;

        public async Task CompleteAsync() => await _context.SaveChangesAsync();

    }
}