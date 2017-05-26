using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega.Domain.Entities;
using Vega.Infra.Data.Context;
using VegaApi.ViewModels;

namespace VegaApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Models")]
    public class ModelsController : Controller
    {
        private readonly VegaDbContext _context;
        private readonly IMapper _mapper;
        public ModelsController(VegaDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }


        [HttpGet("/api/models")]
        public async Task<IEnumerable<KeyValuePairViewModel>> GetMakes()
        {
            var models = await _context.Models.ToListAsync();
            return _mapper.Map<List<Model>, List<KeyValuePairViewModel>>(models);
        }
    }
}