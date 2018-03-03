using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp.Model;
using QuizApp.Persistence;

namespace QuizApp.Controllers
{
    [Produces("application/json")]
    [Route("api/Difficulties")]
    public class DifficultiesController : Controller
    {
        private readonly AppDBContext _context;

        public DifficultiesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Difficulties
        [HttpGet]
        public IEnumerable<Difficulty> GetDifficulty()
        {
            return _context.Difficulty;
        }

        // GET: api/Difficulties/5
        [HttpGet("{difficulty1}")]
        public async Task<IActionResult> GetDifficulty([FromRoute] string difficulty1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var difficulty = await _context.Difficulty.SingleOrDefaultAsync(m => m.DifficultyLevel == difficulty1);

            if (difficulty == null)
            {
                return NotFound();
            }
            Console.WriteLine(difficulty.Id);
            return Ok(difficulty);
        }

        // PUT: api/Difficulties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDifficulty([FromRoute] int id, [FromBody] Difficulty difficulty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != difficulty.Id)
            {
                return BadRequest();
            }

            _context.Entry(difficulty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DifficultyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Difficulties
        [HttpPost]
        public async Task<IActionResult> PostDifficulty([FromBody] Difficulty difficulty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Difficulty.Add(difficulty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDifficulty", new { id = difficulty.Id }, difficulty);
        }

        // DELETE: api/Difficulties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDifficulty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var difficulty = await _context.Difficulty.SingleOrDefaultAsync(m => m.Id == id);
            if (difficulty == null)
            {
                return NotFound();
            }

            _context.Difficulty.Remove(difficulty);
            await _context.SaveChangesAsync();

            return Ok(difficulty);
        }

        private bool DifficultyExists(int id)
        {
            return _context.Difficulty.Any(e => e.Id == id);
        }
    }
}