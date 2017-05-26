using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vega.Domain.Entities;
using Vega.Domain.Interfaces;
using Vega.Domain.Queries;
using VegaApi.ViewModels;

namespace VegaApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Vehicles")]
    public class VehiclesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IVehicleRepository _repository;

        public VehiclesController(IMapper mapper, IUnitOfWork uow, IVehicleRepository repository)
        {
            _mapper = mapper;
            _uow = uow;
            _repository = repository;
        }


        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] VehicleViewModel vehicleViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var vehicle = _mapper.Map<VehicleViewModel, Vehicle>(vehicleViewModel);
            vehicle.LastUpdate = DateTime.Now;
            await _repository.Add(vehicle);
            await _uow.CompleteAsync();

            var result = _mapper.Map<Vehicle, VehicleViewModel>(await _repository.GetVehicle(vehicle.Id));

            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle(int id, [FromBody] VehicleViewModel vehicleViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var vehicle = await _repository.GetVehicle(id);

            if (vehicle == null) return NotFound();

            _mapper.Map(vehicleViewModel, vehicle);

            _repository.Update(vehicle);
            vehicle.LastUpdate = DateTime.Now;

            await _uow.CompleteAsync();

            var result = _mapper.Map<Vehicle, VehicleViewModel>(await _repository.GetVehicle(vehicle.Id));

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle(int id)
        {
            var vehicle = await _repository.GetVehicle(id, false);
            if (vehicle == null) return NotFound();

            _repository.Delete(vehicle);

            await _uow.CompleteAsync();

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await _repository.GetVehicle(id);
            if (vehicle == null) return NotFound();

            var vehicleViewModel = _mapper.Map<Vehicle, VehicleViewModel>(vehicle);

            return Ok(vehicleViewModel);
        }

        [HttpGet]
        public async Task<QueryResultViewModel<VehicleViewModel>> GetVehicles(VehicleQueryViewModel filterViewModel)
        {
            var filter = _mapper.Map<VehicleQuery>(filterViewModel);

            var queryResult = await _repository.GetAll(filter);
            
            return _mapper.Map<QueryResult<Vehicle>, QueryResultViewModel<VehicleViewModel>>(queryResult);


        }
    }
}
