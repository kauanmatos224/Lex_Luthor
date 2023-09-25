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
        
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get(){
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);

            if (hero==null) return BadRequest("Hero not found.");
            
            return hero;
            
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            await _context.SuperHeroes.AddAsync(hero);
            await _context.SaveChangesAsync();
            
            var heroes = await _context.SuperHeroes.ToListAsync();
            return Ok(heroes);
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> Update(SuperHero request)
        {
            var hero = _context.SuperHeroes.FindAsync(request.Id);
            
            if (hero == null) return BadRequest("Hero not found");

            hero.Result.Name = request.Name;
            hero.Result.FirstName = request.FirstName;
            hero.Result.LastName = request.LastName;
            hero.Result.Place = request.Place;

            await _context.SaveChangesAsync();

            var heroes = await _context.SuperHeroes.ToListAsync(); 
            return Ok(heroes);
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();

            var heroes = await _context.SuperHeroes.ToListAsync();
            return Ok(heroes);
        }
    }