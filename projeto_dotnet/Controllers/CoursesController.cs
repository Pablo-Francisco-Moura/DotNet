using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projeto_dotnet.Data;
using projeto_dotnet.Models;

namespace projeto_dotnet.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly Context _context;

        public CoursesController(Context context)
        {
            _context = context;
        }

        // GET: api/Courses
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoursesModel>>> GetCoursesModels()
        {
            return await _context.CoursesModels.ToListAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoursesModel>> GetCoursesModel(int id)
        {
            var coursesModel = await _context.CoursesModels.FindAsync(id);

            if (coursesModel == null)
            {
                return NotFound();
            }

            return coursesModel;
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoursesModel(int id, CoursesModel coursesModel)
        {
            if (id != coursesModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(coursesModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursesModelExists(id))
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

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CoursesModel>> PostCoursesModel(CoursesModel coursesModel)
        {
            _context.CoursesModels.Add(coursesModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoursesModel", new { id = coursesModel.Id }, coursesModel);
        }

        // DELETE: api/Courses/5
        [Authorize(Roles = "Adimin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoursesModel(int id)
        {
            var coursesModel = await _context.CoursesModels.FindAsync(id);
            if (coursesModel == null)
            {
                return NotFound();
            }

            _context.CoursesModels.Remove(coursesModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoursesModelExists(int id)
        {
            return _context.CoursesModels.Any(e => e.Id == id);
        }
    }
}
