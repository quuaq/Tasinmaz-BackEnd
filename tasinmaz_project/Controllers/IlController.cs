using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using tasinmaz_project.DataAccess;
using tasinmaz_project.Entities.Concrete;

[ApiController]
[Route("api/[controller]")]
public class IlController : ControllerBase
{
    private readonly Context _context;

    public IlController(Context context)
    {
        _context = context;
    }

    // GET: api/Il
    [HttpGet]
    public ActionResult<IEnumerable<Sehir>> GetIller()
    {
        return _context.sehir.ToList();
    }

    // GET: api/Il/5
    [HttpGet("{id}")]
    public ActionResult<Sehir> GetIl(int id)
    {
        var il = _context.sehir.Find(id);
        if (il == null)
        {
            return NotFound();
        }
        return il;
    }

    // POST: api/Il
    [HttpPost]
    public ActionResult<Sehir> PostIl(Sehir il)
    {
        _context.sehir.Add(il);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetIl), new { id = il.sehir_id }, il);
    }

    // PUT: api/Il/5
    [HttpPut("{id}")]
    public IActionResult PutIl(int id, Sehir il)
    {
        if (id != il.sehir_id)
        {
            return BadRequest();
        }
        _context.Entry(il).State = EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
    }

    // DELETE: api/Il/5
    [HttpDelete("{id}")]
    public IActionResult DeleteIl(int id)
    {
        var il = _context.sehir.Find(id);
        if (il == null)
        {
            return NotFound();
        }
        _context.sehir.Remove(il);
        _context.SaveChanges();
        return NoContent();
    }
}
