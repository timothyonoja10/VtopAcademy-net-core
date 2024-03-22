using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VtopAcademy.Accounts;

namespace VtopAcademy.Schools
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SchoolsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Schools
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SchoolDTO>>> GetSchools()
        {
            return await _context.Schools
                .Select(x => SchoolToDTO(x))
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SchoolDTO>> GetSchool(long id)
        {
            var school = await _context.Schools.FindAsync(id);

            if (school == null)
            {
                return NotFound();
            }

            return SchoolToDTO(school);
        }

        // POST: api/Schools
        [HttpPost]
        public async Task<ActionResult<SchoolDTO>> PostSchool(SchoolDTO schoolDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var school = new School
            {
                Name = schoolDTO.Name,
                Number = schoolDTO.Number
            };

            _context.Schools.Add(school);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetSchool),
                new { id = school.SchoolId },
                SchoolToDTO(school));
        }

        // PUT: api/Schools/SchoolID 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSchool(long id, SchoolDTO schoolDTO)
        {
            if (!ModelState.IsValid || id != schoolDTO.SchoolID)
            {
                return BadRequest();
            }

            var school = await _context.Schools.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }

            school.Name = schoolDTO.Name;
            school.Number = schoolDTO.Number;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!SchoolExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Schools/SchoolID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var school = await _context.Schools.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }

            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SchoolExists(long schoolID)
        {
            return _context.Schools.Any(e => e.SchoolId == schoolID);
        }

        private static SchoolDTO SchoolToDTO(School school) =>
           new SchoolDTO
           {
               SchoolID = school.SchoolId,
               Name = school.Name,
               Number = school.Number
           };

    }
}
