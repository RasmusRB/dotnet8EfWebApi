using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityTestApi.Data;
using EntityTestApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityTestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            List<SuperHero> superHeroes = await _context.SuperHeroes.ToListAsync();
            return Ok(superHeroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            SuperHero hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return NotFound("Hero not found");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<SuperHero>> AddHero(SuperHero hero)
        {
            _context.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(hero);
        }

        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero hero)
        {
            _context.Update(hero);
            await _context.SaveChangesAsync();
            return Ok(hero);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteHero(int id)
        {
            SuperHero hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
            {
                return NotFound("Hero not found");
            }
            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            return Ok(hero);
        }
    }
}
