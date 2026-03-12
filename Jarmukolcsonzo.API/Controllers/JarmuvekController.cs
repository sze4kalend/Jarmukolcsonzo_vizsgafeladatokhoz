using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Jarmukolcsonzo.API.Data;
using Jarmukolcsonzo.Shared.Models;
using Jarmukolcsonzo.Shared.DTOs;

namespace Jarmukolcsonzo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JarmuvekController : ControllerBase
    {
        private readonly JKContext _context;

        public JarmuvekController(JKContext context)
        {
            _context = context;
        }

        // GET: api/Jarmuvek
        [HttpGet]
        public async Task<ActionResult<TableDto<Jarmu>>> Getjarmuvek(
            int page = 1,
            int itemsPerPage = 20,
            string? searchKey = null,
            string? sortkey = null,
            bool ascending = true)
        {
            var query = _context.jarmuvek.Include(x => x.tipus).AsQueryable();

            //Összes elem számolása
            int totalItems = await query.CountAsync();

            //Keresés
            if (string.IsNullOrWhiteSpace(searchKey))
            { 
                searchKey = searchKey.ToLower();
                int.TryParse(searchKey, out int dij);
                DateTime.TryParse(searchKey, out DateTime datum);

            }

            //Lapozás
            if (page > 0 && itemsPerPage > 0)
                {
                    query = query.Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
                }
            var data = await query.ToListAsync();   //SQL parancs lefuttatása
            return new TableDto<Jarmu>(data, totalItems);
        }

        // GET: api/Jarmuvek/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jarmu>> GetJarmu(int id)
        {
            var jarmu = await _context.jarmuvek.FindAsync(id);

            if (jarmu == null)
            {
                return NotFound();
            }

            return jarmu;
        }

        // PUT: api/Jarmuvek/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJarmu(int id, Jarmu jarmu)
        {
            if (id != jarmu.id)
            {
                return BadRequest();
            }

            _context.Entry(jarmu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JarmuExists(id))
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

        // POST: api/Jarmuvek
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jarmu>> PostJarmu(Jarmu jarmu)
        {
            jarmu.tipus = null; // Jármű típust ne hozzon létre újra
            _context.jarmuvek.Add(jarmu);

            await _context.SaveChangesAsync();
            return CreatedAtAction("GetJarmu", new { id = jarmu.id }, jarmu);
        }

        // DELETE: api/Jarmuvek/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJarmu(int id)
        {
            var jarmu = await _context.jarmuvek.FindAsync(id);
            if (jarmu == null)
            {
                return NotFound();
            }

            _context.jarmuvek.Remove(jarmu);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool JarmuExists(int id)
        {
            return _context.jarmuvek.Any(e => e.id == id);
        }
    }
}
