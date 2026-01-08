
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pratices_angular_CURD.Data;
using pratices_angular_CURD.Dtos;
using System.Threading.Tasks;

namespace pratices_angular_CURD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly studentDbContext _context;

        public StudentController(studentDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentasyn()
        {
            var std = await _context.Students.ToListAsync();
            return Ok(std);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudentByIdasyn(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
                return NotFound(); 

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = StudentMappings.ToEntity(dto);

            await _context.Students.AddAsync(entity); 
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudentByIdasyn), new { id = entity.stdid }, entity);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CreateStudentDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Load existing entity
            var existing = await _context.Students.FindAsync(id);
            if (existing == null)
                return NotFound(); 
            StudentMappings.UpdateEntity(existing, dto);

            _context.Entry(existing).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict("Concurrency conflict while updating the student.");
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var existing = await _context.Students.FindAsync(id);
            if (existing == null)
                return NotFound();

            _context.Students.Remove(existing);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
