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
    //[Produces("application/json")]
    [Route("api/Options")]
    public class OptionsController : Controller
    {
        private readonly AppDBContext _context;

        public OptionsController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Options
        [HttpGet]
        public IEnumerable<Option> GetOption()
        {
            return _context.Option;
        }

        // GET: api/Options/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var option = await _context.Option.SingleOrDefaultAsync(m => m.Id == id);

            if (option == null)
            {
                return NotFound();
            }

            return new OkObjectResult(option);
        }

        // PUT: api/Options/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOption([FromRoute] int id, [FromBody] Option option)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != option.Id)
            {
                return BadRequest();
            }

            _context.Entry(option).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionExists(id))
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

        // POST: api/Options
        [HttpPost]
        public async Task<IActionResult> PostOption([FromBody] List<Option> options)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (Option o in options)
            {
                _context.Option.Add(o);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("Success", new Option());
        }

        public string AddOptions(List<Option> options)
        {

            int i = 0;
           
            foreach (Option o in options)
            {
                
                Task<int> x;
                _context.Option.Add(o);
               x =  _context.SaveChangesAsync();
               
            }

            return "Success";

            

        }

        // DELETE: api/Options/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOption([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var option = await _context.Option.SingleOrDefaultAsync(m => m.Id == id);
            if (option == null)
            {
                return NotFound();
            }

            _context.Option.Remove(option);
            await _context.SaveChangesAsync();

            return Ok(option);
        }

        private bool OptionExists(int id)
        {
            return _context.Option.Any(e => e.Id == id);
        }
    }
}