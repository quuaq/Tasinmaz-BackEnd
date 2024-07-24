//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using tasinmaz_project.DataAccess;
//using tasinmaz_project.Entities.Concrete;

//[ApiController]
//[Route("api/[controller]")]
//public class TasinmazController : ControllerBase
//{
//    private readonly Context _context;

//    public TasinmazController(Context context)
//    {
//        _context = context;
//    }

//    // GET: api/Tasinmaz
//    [HttpGet]
//    public ActionResult<IEnumerable<Tasinmaz>> GetTasinmazlar()
//    {
//        return _context.tasinmaz.ToList();
//    }

//    // GET: api/Tasinmaz/5
//    [HttpGet("{id}")]
//    public ActionResult<Tasinmaz> GetTasinmaz(int id)
//    {
//        var tasinmaz = _context.tasinmaz.Find(id);
//        if (tasinmaz == null)
//        {
//            return NotFound();
//        }
//        return tasinmaz;
//    }

//    // POST: api/Tasinmaz
//    [HttpPost]
//    public ActionResult<Tasinmaz> PostTasinmaz(Tasinmaz tasinmaz)
//    {
//        _context.tasinmaz.Add(tasinmaz);
//        _context.SaveChanges();
//        return CreatedAtAction(nameof(GetTasinmaz), new { id = tasinmaz.tasinmaz_id }, tasinmaz);
//    }

//    // PUT: api/Tasinmaz/5
//    [HttpPut("{id}")]
//    public IActionResult PutTasinmaz(int id, Tasinmaz tasinmaz)
//    {
//        if (id != tasinmaz.tasinmaz_id)
//        {
//            return BadRequest();
//        }
//        _context.Entry(tasinmaz).State = EntityState.Modified;
//        _context.SaveChanges();
//        return NoContent();
//    }

//    // DELETE: api/Tasinmaz/5
//    [HttpDelete("{id}")]
//    public IActionResult DeleteTasinmaz(int id)
//    {
//        var tasinmaz = _context.tasinmaz.Find(id);
//        if (tasinmaz == null)
//        {
//            return NotFound();
//        }
//        _context.tasinmaz.Remove(tasinmaz);
//        _context.SaveChanges();
//        return NoContent();
//    }
//}


// GÜNCELLENMİŞ TAŞINMAZ API
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using tasinmaz_project.DataAccess;
//using tasinmaz_project.Entities.Concrete;

//[ApiController]
//[Route("api/[controller]")]
//public class TasinmazController : ControllerBase
//{
//    private readonly Context _context;

//    public TasinmazController(Context context)
//    {
//        _context = context;
//    }

//    // GET: api/Tasinmaz
//    [HttpGet]
//    public ActionResult<IEnumerable<Tasinmaz>> GetTasinmazlar()
//    {
//        return _context.tasinmaz
//                       .Include(t => t.Mahalle)
//                       .ThenInclude(m => m.Ilce)
//                       .ThenInclude(i => i.Sehir)
//                       .ToList();
//    }

//    // GET: api/Tasinmaz/5
//    [HttpGet("{id}")]
//    public ActionResult<Tasinmaz> GetTasinmaz(int id)
//    {
//        var tasinmaz = _context.tasinmaz
//                               .Include(t => t.Mahalle)
//                               .ThenInclude(m => m.Ilce)
//                               .ThenInclude(i => i.Sehir)
//                               .FirstOrDefault(t => t.tasinmaz_id == id);
//        if (tasinmaz == null)
//        {
//            return NotFound();
//        }
//        return tasinmaz;
//    }

//    // POST: api/Tasinmaz
//    [HttpPost]
//    public ActionResult<Tasinmaz> PostTasinmaz(Tasinmaz tasinmaz)
//    {
//        var mahalle = _context.mahalle
//                              .Include(m => m.Ilce)
//                              .ThenInclude(i => i.Sehir)
//                              .FirstOrDefault(m => m.mahalle_id == tasinmaz.mahalle_id);

//        if (mahalle == null)
//        {
//            return BadRequest("Invalid Mahalle ID");
//        }

//        tasinmaz.Mahalle = mahalle;

//        _context.tasinmaz.Add(tasinmaz);
//        _context.SaveChanges();
//        return CreatedAtAction(nameof(GetTasinmaz), new { id = tasinmaz.tasinmaz_id }, tasinmaz);
//    }

//    // PUT: api/Tasinmaz/5
//    [HttpPut("{id}")]
//    public IActionResult PutTasinmaz(int id, Tasinmaz tasinmaz)
//    {
//        if (id != tasinmaz.tasinmaz_id)
//        {
//            return BadRequest();
//        }

//        var mahalle = _context.mahalle
//                              .Include(m => m.Ilce)
//                              .ThenInclude(i => i.Sehir)
//                              .FirstOrDefault(m => m.mahalle_id == tasinmaz.mahalle_id);

//        if (mahalle != null)
//        {
//            tasinmaz.Mahalle = mahalle;
//        }

//        _context.Entry(tasinmaz).State = EntityState.Modified;
//        _context.SaveChanges();
//        return NoContent();
//    }

//    // DELETE: api/Tasinmaz/5
//    [HttpDelete("{id}")]
//    public IActionResult DeleteTasinmaz(int id)
//    {
//        var tasinmaz = _context.tasinmaz.Find(id);
//        if (tasinmaz == null)
//        {
//            return NotFound();
//        }
//        _context.tasinmaz.Remove(tasinmaz);
//        _context.SaveChanges();
//        return NoContent();
//    }
//}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using tasinmaz_project.DataAccess;
using tasinmaz_project.Entities.Concrete;

[ApiController]
[Route("api/[controller]")]
public class TasinmazController : ControllerBase
{
    private readonly Context _context;

    public TasinmazController(Context context)
    {
        _context = context;
    }

    // GET: api/Tasinmaz
    [HttpGet]
    public ActionResult<IEnumerable<Tasinmaz>> GetTasinmazlar()
    {
        return _context.tasinmaz
                       .Include(t => t.Mahalle)
                       .ThenInclude(m => m.Ilce)
                       .ThenInclude(i => i.Sehir)
                       .ToList();
    }

    // GET: api/Tasinmaz/5
    [HttpGet("{id}")]
    public ActionResult<Tasinmaz> GetTasinmaz(int id)
    {
        var tasinmaz = _context.tasinmaz
                               .Include(t => t.Mahalle)
                               .ThenInclude(m => m.Ilce)
                               .ThenInclude(i => i.Sehir)
                               .FirstOrDefault(t => t.tasinmaz_id == id);
        if (tasinmaz == null)
        {
            return NotFound();
        }
        return tasinmaz;
    }

    // GET: api/Tasinmaz/iller
    [HttpGet("iller")]
    public ActionResult<IEnumerable<Sehir>> GetIller()
    {
        return _context.sehir.ToList();
    }

    // GET: api/Tasinmaz/iller/{ilId}/ilceler
    [HttpGet("iller/{ilId}/ilceler")]
    public ActionResult<IEnumerable<Ilce>> GetIlceler(int ilId)
    {
        var ilceler = _context.ilce
                              .Include(ilce => ilce.Sehir)  // Bu satırı ekleyin
                              .Where(ilce => ilce.sehir_id == ilId)
                              .ToList();
        if (ilceler == null || !ilceler.Any())
        {
            return NotFound("No ilceler found for the given ilId");
        }
        return ilceler;
    }

    //TÜM İLÇELERİ İL OLMADAN GETİREN KISIM
    // GET: api/Tasinmaz/ilceler
    [HttpGet("ilceler")]
    public ActionResult<IEnumerable<Ilce>> GetAllIlceler()
    {
        var ilceler = _context.ilce
                              .Include(ilce => ilce.Sehir)
                              .ToList();
        if (ilceler == null || !ilceler.Any())
        {
            return NotFound("No ilceler found");
        }
        return ilceler;
    }
    // GET: api/Tasinmaz/ilceler/{ilceId}/mahalleler
    [HttpGet("ilceler/{ilceId}/mahalleler")]
    public ActionResult<IEnumerable<Mahalle>> GetMahalleler(int ilceId)
    {
        var mahalleler = _context.mahalle
                                  .Include(m => m.Ilce)  // Bu satırı ekleyin
                                  .Where(mahalle => mahalle.ilce_id == ilceId)
                                  .ToList();

        if (mahalleler == null || !mahalleler.Any())
        {
            return NotFound("No mahalleler found for the given ilceId");
        }

        return mahalleler;
    }
    // POST: api/Tasinmaz
    [HttpPost]
    public ActionResult<Tasinmaz> PostTasinmaz(Tasinmaz tasinmaz)
    {
        var mahalle = _context.mahalle
                              .Include(m => m.Ilce)
                              .ThenInclude(i => i.Sehir)
                              .FirstOrDefault(m => m.mahalle_id == tasinmaz.mahalle_id);

        if (mahalle == null)
        {
            return BadRequest("Invalid Mahalle ID");
        }

        tasinmaz.Mahalle = mahalle;

        _context.tasinmaz.Add(tasinmaz);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetTasinmaz), new { id = tasinmaz.tasinmaz_id }, tasinmaz);
    }

    // PUT: api/Tasinmaz/5
    [HttpPut("{id}")]
    public IActionResult PutTasinmaz(int id, Tasinmaz tasinmaz)
    {
        if (id != tasinmaz.tasinmaz_id)
        {
            return BadRequest();
        }

        var mahalle = _context.mahalle
                              .Include(m => m.Ilce)
                              .ThenInclude(i => i.Sehir)
                              .FirstOrDefault(m => m.mahalle_id == tasinmaz.mahalle_id);

        if (mahalle != null)
        {
            tasinmaz.Mahalle = mahalle;
        }

        _context.Entry(tasinmaz).State = EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
    }

    // DELETE: api/Tasinmaz/5
    [HttpDelete("{id}")]
    public IActionResult DeleteTasinmaz(int id)
    {
        var tasinmaz = _context.tasinmaz.Find(id);
        if (tasinmaz == null)
        {
            return NotFound();
        }
        _context.tasinmaz.Remove(tasinmaz);
        _context.SaveChanges();
        return NoContent();
    }
}

