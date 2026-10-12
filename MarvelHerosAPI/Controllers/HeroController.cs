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

        [HttpGet("{id}")]
        public async Task<ActionResult<Hero>> GetHeroById(int id)
        {
            var dbHero = await _context.Heros.FindAsync(id);
            if (dbHero is null)
            {
                return NotFound("No Heros were found!!");
            }
            return Ok(dbHero);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHero(Hero hero)
        {
            try
            {
                var dbHero = _context.Heros.Add(hero);
                _context.SaveChanges();
                return Ok("SuccessFully Inserted");
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
                return BadRequest("Hero Not created... \n Something went wrong.");
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHero ([FromBody] Hero hero)
        {
            // 1. Find the existing Hero
            var dbHero = await _context.Heros.FindAsync(hero.Id);
            if (dbHero is null)
            {
                return NotFound("No Heros were found!!");
            }
            // 2. update the values of the dbHero with latest hero value
            dbHero.HeroName = hero.HeroName;
            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.UniverseNumber = hero.UniverseNumber;
            dbHero.OwnedBy = hero.OwnedBy;
            dbHero.Place = hero.Place;

            _context.SaveChanges();
            return Ok("SuccessFully Updated!!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var dbHero = await _context.Heros.FindAsync(id);
            if (dbHero is null)
            {
                return NotFound("No Heros were found!!");
            }
            var heroName = dbHero.HeroName;
            _context.Heros.Remove(dbHero);
            _context.SaveChanges();
            return Ok($"Successfully Deleted Hero: {heroName}");
        }
    }
}
