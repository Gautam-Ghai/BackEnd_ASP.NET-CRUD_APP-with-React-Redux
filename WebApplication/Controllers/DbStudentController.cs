using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbStudentController : ControllerBase
    {
        private readonly StudentDbContext _context;

        public DbStudentController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: api/DbStudent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DbStudent>>> GetDbStudents()
        {
            return await _context.DbStudents.ToListAsync();
        }

        // GET: api/DbStudent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DbStudent>> GetDbStudent(int id)
        {
            var dbStudent = await _context.DbStudents.FindAsync(id);

            if (dbStudent == null)
            {
                return NotFound();
            }

            return dbStudent;
        }

        // PUT: api/DbStudent/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDbStudent(int id, DbStudent dbStudent)
        {
            dbStudent.Id = id;

            _context.Entry(dbStudent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DbStudentExists(id))
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

        // POST: api/DbStudent
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DbStudent>> PostDbStudent(DbStudent dbStudent)
        {
            _context.DbStudents.Add(dbStudent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDbStudent", new { id = dbStudent.Id }, dbStudent);
        }

        // DELETE: api/DbStudent/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DbStudent>> DeleteDbStudent(int id)
        {
            var dbStudent = await _context.DbStudents.FindAsync(id);
            if (dbStudent == null)
            {
                return NotFound();
            }

            _context.DbStudents.Remove(dbStudent);
            await _context.SaveChangesAsync();

            return dbStudent;
        }

        private bool DbStudentExists(int id)
        {
            return _context.DbStudents.Any(e => e.Id == id);
        }
    }
}
