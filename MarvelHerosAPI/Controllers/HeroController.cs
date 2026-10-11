using MarvelHerosAPI.Data;
using MarvelHerosAPI.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarvelHerosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly DataContext _context;

        public HeroController(DataContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hero>>> GetAllHeroes()
        {
            var heros = await _context.Heros.ToListAsync();
            return Ok(heros);
        }

        [HttpPost]
        public async Task<ActionResult<Hero>> CreateHero(Hero hero)
        {
            return Ok();
        }
    }
}
