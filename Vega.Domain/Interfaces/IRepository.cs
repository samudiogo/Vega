using System.Collections.Generic;
using System.Threading.Tasks;


namespace Vega.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {

        Task<IEnumerable<TEntity>> GetAll(bool includedRelated = true);
        Task<TEntity> GetVehicle(int id, bool includeRelated = true);
        Task Add(TEntity vehicle);
        void Update(TEntity vehicle);
        void Delete(TEntity vehicle);
    }
}