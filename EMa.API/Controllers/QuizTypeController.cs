using EMa.Data.DataContext;
using EMa.Data.Entities;
using EMa.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMa.API.Controllers
{
    [ApiController]
    [Route("quizType")]
    public class QuizTypeController : Controller
    {
        private readonly DataDbContext _context;

        public QuizTypeController(DataDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<IEnumerable<QuizType>>> GetQuizTypes()
        {
            return await _context.QuizTypes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<QuizType>> GetQuizType(Guid id)
        {
            var quizType = await _context.QuizTypes.FindAsync(id);

            if (quizType == null)
            {
                return NotFound();
            }

            return Ok(quizType);
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult<QuizType>> PostQuizType(Guid userId, CreateQuizTypeViewModel model)
        {
            QuizType createQuizType = new QuizType()
            {
                Name = model.Name
            };

            _context.QuizTypes.Add(createQuizType);
            await _context.SaveChangesAsync();

            return Ok(createQuizType);
        }

        [HttpPut("{id}/{userId}")]
        public async Task<IActionResult> PutQuizType(Guid id, Guid userId, UpdateQuizTypeViewModel model)
        {
            QuizType updateQuizType = new QuizType()
            {
                Id = id,
                Name = model.Name
            };
            _context.Entry(updateQuizType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuizTypesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(updateQuizType);
        }

        private bool QuizTypesExists(Guid id)
        {
            return _context.QuizTypes.Any(e => e.Id == id);
        }
    }
}
