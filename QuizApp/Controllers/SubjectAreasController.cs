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
    [Route("api/SubjectAreas")]
    public class SubjectAreasController : Controller
    {
        private readonly AppDBContext _context;

        public SubjectAreasController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/SubjectAreas
        [HttpGet]
        public IEnumerable<SubjectArea> GetSubjectArea()
        {
            return _context.SubjectArea;
        }

        // GET: api/SubjectAreas/5
        [HttpGet("{subject}")]
        public async Task<IActionResult> GetSubjectArea([FromRoute] string subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subjectArea = await _context.SubjectArea.SingleOrDefaultAsync(m => m.Area == subject);

            if (subjectArea == null)
            {
                return NotFound();
            }

            return Ok(subjectArea);
        }

        // PUT: api/SubjectAreas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubjectArea([FromRoute] int id, [FromBody] SubjectArea subjectArea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subjectArea.Id)
            {
                return BadRequest();
            }

            _context.Entry(subjectArea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectAreaExists(id))
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

        // POST: api/SubjectAreas
        [HttpPost]
        public async Task<IActionResult> PostSubjectArea([FromBody] SubjectArea subjectArea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SubjectArea.Add(subjectArea);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubjectArea", new { id = subjectArea.Id }, subjectArea);
        }

        // DELETE: api/SubjectAreas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectArea([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subjectArea = await _context.SubjectArea.SingleOrDefaultAsync(m => m.Id == id);
            if (subjectArea == null)
            {
                return NotFound();
            }

            _context.SubjectArea.Remove(subjectArea);
            await _context.SaveChangesAsync();

            return Ok(subjectArea);
        }

        private bool SubjectAreaExists(int id)
        {
            return _context.SubjectArea.Any(e => e.Id == id);
        }
    }
}