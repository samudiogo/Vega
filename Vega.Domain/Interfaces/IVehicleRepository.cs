using System.Threading.Tasks;
using Vega.Domain.Entities;
using Vega.Domain.Queries;

namespace Vega.Domain.Interfaces
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
        Task<QueryResult<Vehicle>> GetAll(VehicleQuery queryObj);
    }
}