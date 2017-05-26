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
    public class MakesController : Controller
    {
        private readonly VegaDbContext _context;
        private readonly IMapper _mapper;
        public MakesController(VegaDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }


        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeViewModel>> GetMakes()
        {
            var makes = await _context.Makes.Include(m => m.Models).ToListAsync();
            return _mapper.Map<List<Make>,List<MakeViewModel>>(makes);
        }
    }
}