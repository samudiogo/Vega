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
    public class FeaturesController : Controller
    {
        private readonly VegaDbContext _context;
        private readonly IMapper _mapper;
        public FeaturesController(VegaDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        [HttpGet("/api/features")]
        public async Task<IEnumerable<KeyValuePairViewModel>> GetFeatures()
        {
            var list = await _context.Features.ToListAsync();
            return _mapper.Map<List<Feature>, List<KeyValuePairViewModel>>(list);
        }
    }
}