using Lex_Luthor.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lex_Luthor.Controllers;

public class SuperHeroController
{
    [Route("api/[controller]")]
    [ApiController]

    public class SuperHeroControlller : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero
                {
                    Id = 1,
                    Name = "Lex Luthor",
                    FirstName = "Lex",
                    LastName = "Luthor",
                    Place = "Gotham City"
                }
            };

            return Ok(heroes);
        }
    }
}