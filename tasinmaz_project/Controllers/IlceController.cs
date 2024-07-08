using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using tasinmaz_project.DataAccess;
using tasinmaz_project.Entities.Concrete;


[ApiController]
[Route("api/[controller]")]
public class IlceController : ControllerBase
{
    private readonly Context _context;

    public IlceController(Context context)
    {
        _context = context;
    }

    // GET: api/Ilce
    [HttpGet]
    public ActionResult<IEnumerable<Ilce>> GetIlceler()
    {
        return _context.ilce.Include(i => i.Sehir).ToList();
    }

    // GET: api/Ilce/5
    [HttpGet("{id}")]
    public ActionResult<Ilce> GetIlce(int id)
    {
        var ilce = _context.ilce.Include(i => i.Sehir).FirstOrDefault(i => i.ilce_id == id);
        if (ilce == null)
        {
            return NotFound();
        }
        return ilce;
    }

    // POST: api/Ilce
    [HttpPost]
    public ActionResult<Ilce> PostIlce(Ilce ilce)
    {
        var sehir = _context.sehir.Find(ilce.sehir_id);
        if (sehir == null)
        {
            return BadRequest("Geçersiz sehir_id");
        }

        ilce.Sehir = sehir;
        _context.ilce.Add(ilce);
        _context.SaveChanges();

        return CreatedAtAction(nameof(GetIlce), new { id = ilce.ilce_id }, ilce);
    }

    // PUT: api/Ilce/5
    [HttpPut("{id}")]
    public IActionResult PutIlce(int id, Ilce ilce)
    {
        if (id != ilce.ilce_id)
        {
            return BadRequest();
        }

        var sehir = _context.sehir.Find(ilce.sehir_id);
        if (sehir == null)
        {
            return BadRequest("Geçersiz sehir_id");
        }

        ilce.Sehir = sehir;
        _context.Entry(ilce).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    // DELETE: api/Ilce/5
    [HttpDelete("{id}")]
    public IActionResult DeleteIlce(int id)
    {
        var ilce = _context.ilce.Find(id);
        if (ilce == null)
        {
            return NotFound();
        }

        _context.ilce.Remove(ilce);
        _context.SaveChanges();

        return NoContent();
    }
}
