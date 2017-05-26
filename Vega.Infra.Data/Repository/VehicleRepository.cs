using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vega.Domain.Entities;
using Vega.Domain.Extensions;
using Vega.Domain.Interfaces;
using Vega.Domain.Queries;
using Vega.Infra.Data.Context;

namespace Vega.Infra.Data.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VegaDbContext _context;
        public VehicleRepository(VegaDbContext context) => _context = context;

        public async Task Add(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
        }

        public void Update(Vehicle vehicle)
        {
            _context.Vehicles.Update(vehicle);
        }

        public async Task<Vehicle> GetVehicle(int id, bool includeRelated = true)
        {
            if (!includeRelated) return await _context.Vehicles.FindAsync(id);

            return await _context.Vehicles.Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
                .Include(vf => vf.Model)
                .ThenInclude(m => m.Make)
                .SingleOrDefaultAsync(v => v.Id == id);
        }

        public void Delete(Vehicle vehicle)
        {
            _context.Vehicles.Remove(vehicle);
        }

        public async Task<QueryResult<Vehicle>> GetAll(VehicleQuery queryObj)
        {
            var result = new QueryResult<Vehicle>();
            var query = _context.Vehicles.Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
                .Include(vf => vf.Model)
                .ThenInclude(m => m.Make).AsQueryable();

            if (queryObj.MakeId.HasValue)
                query = query.Where(v => v.Model.MakeId == queryObj.MakeId.Value);

            if (queryObj.ModelId.HasValue)
                query = query.Where(v => v.ModelId.Equals(queryObj.ModelId.Value));


            query = query.ApplyOrdering(queryObj, GetColumnsMap());

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();
            
            return result;
        }

        public async Task<IEnumerable<Vehicle>> GetAll(bool includedRelated = true)
        {
            if (!includedRelated) return await _context.Vehicles.ToListAsync();

            return await _context.Vehicles.Include(v => v.Features)
                .ThenInclude(vf => vf.Feature)
                .Include(vf => vf.Model)
                .ThenInclude(m => m.Make).ToListAsync();
        }

        private Dictionary<string, Expression<Func<Vehicle, object>>> GetColumnsMap()
        {
            return new Dictionary<string, Expression<Func<Vehicle, object>>>
            {
                ["make"] = v => v.Model.Make.Name,
                ["model"] = v => v.Model.Name,
                ["contact"] = v => v.ContactName
            };
        }


    }
}