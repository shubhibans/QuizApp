using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp.Model;
using QuizApp.Persistence;
using QuizApp.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Controllers
{
    
    [Route("api/Questions")]
    public class QuestionsController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IMapper _mapper;

        public QuestionsController(AppDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Questions
        [HttpGet]
        public IEnumerable<Question> GetQuestion()
        {
            return _context.Question;
        }

        // GET: api/Questions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var question = await _context.Question.SingleOrDefaultAsync(m => m.Id == id);

            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        // PUT: api/Questions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion([FromRoute] string id, [FromBody] Question question)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != question.Id)
            {
                return BadRequest();
            }

            _context.Entry(question).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
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

        // POST: api/Questions
        [HttpPost]
        public async Task<IActionResult> PostQuestion([FromBody] QuestionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var diff = new DifficultiesController(_context).getDifficultyMethod(model.Difficulty);
            var subject =  new SubjectAreasController(_context).getSubArea(model.Subject);
            var questtype = new QuestionTypesController(_context).getQuestType(model.Questiontype);

            //var result=new OptionsController(_context)
            Question Question1 = new Question
            {
                Difficulty = diff,
                SubjectArea = subject,
                Question_txt = model.Questiontext,
                QuestionType = questtype,
                Answered = false
            };

            _context.Question.Add(Question1);
            var result = await _context.SaveChangesAsync();

            List<Option> options = new List<Option>();
            int i = 1;
            foreach (string a in model.Options1)
            {
                if (i == 1)
                    options.Add(new Option { Question = Question1, Body = a, IsAnswer = true });
                else
                {
                    options.Add(new Option { Question = Question1, Body = a });
                }

                i++;
            }

            var result1 = new OptionsController(_context).AddOptions(options);
            int y = 0;
            return new OkObjectResult("Questiom created"); ;
        }

        // DELETE: api/Questions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var question = await _context.Question.SingleOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            _context.Question.Remove(question);
            await _context.SaveChangesAsync();

            return Ok(question);
        }

        private bool QuestionExists(string id)
        {
            return _context.Question.Any(e => e.Id == id);
        }
    }
}