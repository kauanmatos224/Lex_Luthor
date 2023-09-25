using Lex_Luthor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lex_Luthor.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            this._context = context;
        }

        private static List<SuperHero>? _heroes = new List<SuperHero>
        {
            
            new SuperHero
            {
                Id = 2,
                Name = "Ironman",
                FirstName = "Tony",
                LastName = "Stark",
                Place = "New York City"
            }
        };
        
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get(){
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = _heroes.Find(h => h.Id == id);

            if (hero==null) return BadRequest("Hero not found.");
            
            return hero;
            
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _heroes.Add(hero);

            return Ok(_heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> Update(SuperHero request)
        {
            var hero = _heroes.Find(h => h.Id == request.Id);
            if (hero==null) return BadRequest("Hero not found.");

            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;

            return Ok(_heroes);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = _heroes.Find(h => h.Id == id);
            if (hero==null) return BadRequest("Hero not found.");
            _heroes.Remove(hero);
            return Ok(_heroes);
        }
    }