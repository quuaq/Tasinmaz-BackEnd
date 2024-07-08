//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Linq;
//using tasinmaz_project.DataAccess;
//using tasinmaz_project.Entities.Concrete;

//[ApiController]
//[Route("api/[controller]")]
//public class MahalleController : ControllerBase
//{
//    private readonly Context _context;

//    public MahalleController(Context context)
//    {
//        _context = context;
//    }

//    // GET: api/Mahalle
//    [HttpGet]
//    public ActionResult<IEnumerable<Mahalle>> GetMahalleler()
//    {
//        return _context.mahalle.Include(m => m.Ilce).ToList();
//    }

//    // GET: api/Mahalle/5
//    [HttpGet("{id}")]
//    public ActionResult<Mahalle> GetMahalle(int id)
//    {
//        var mahalle = _context.mahalle.Include(m => m.Ilce).FirstOrDefault(m => m.mahalle_id == id);
//        if (mahalle == null)
//        {
//            return NotFound();
//        }
//        return mahalle;
//    }

//    [HttpPost]
//    public IActionResult CreateMahalle([FromBody] Mahalle mahalle)
//    {
//        if (mahalle == null)
//        {
//            return BadRequest();
//        }

//        var ilce = _context.ilce.Find(mahalle.ilce_id);
//        if (ilce == null)
//        {
//            return NotFound();
//        }

//        mahalle.Ilce = ilce;

//        _context.mahalle.Add(mahalle);
//        _context.SaveChanges();

//        return Ok(mahalle);
//    }

//    // PUT: api/Mahalle/5
//    [HttpPut("{id}")]
//    public IActionResult PutMahalle(int id, Mahalle mahalle)
//    {
//        if (id != mahalle.mahalle_id)
//        {
//            return BadRequest();
//        }
//        _context.Entry(mahalle).State = EntityState.Modified;
//        _context.SaveChanges();
//        return NoContent();
//    }

//    // DELETE: api/Mahalle/5
//    [HttpDelete("{id}")]
//    public IActionResult DeleteMahalle(int id)
//    {
//        var mahalle = _context.mahalle.Find(id);
//        if (mahalle == null)
//        {
//            return NotFound();
//        }
//        _context.mahalle.Remove(mahalle);
//        _context.SaveChanges();
//        return NoContent();
//    }
//}




//Asıl kod yukarıda ki alan BURASI DÜZELTİLMİŞ YER 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using tasinmaz_project.DataAccess;
using tasinmaz_project.Entities.Concrete;

[ApiController]
[Route("api/[controller]")]
public class MahalleController : ControllerBase
{
    private readonly Context _context;

    public MahalleController(Context context)
    {
        _context = context;
    }

    // GET: api/Mahalle
    [HttpGet]
    public ActionResult<IEnumerable<Mahalle>> GetMahalleler()
    {
        return _context.mahalle
                       .Include(m => m.Ilce)
                       .ThenInclude(i => i.Sehir)
                       .ToList();
    }

    // GET: api/Mahalle/5
    [HttpGet("{id}")]
    public ActionResult<Mahalle> GetMahalle(int id)
    {
        var mahalle = _context.mahalle
                              .Include(m => m.Ilce)
                              .ThenInclude(i => i.Sehir)
                              .FirstOrDefault(m => m.mahalle_id == id);
        if (mahalle == null)
        {
            return NotFound();
        }
        return mahalle;
    }

    [HttpPost]
    public IActionResult CreateMahalle([FromBody] Mahalle mahalle)
    {
        if (mahalle == null)
        {
            return BadRequest();
        }

        var ilce = _context.ilce.Include(i => i.Sehir).FirstOrDefault(i => i.ilce_id == mahalle.ilce_id);
        if (ilce == null)
        {
            return NotFound();
        }

        mahalle.Ilce = ilce;

        _context.mahalle.Add(mahalle);
        _context.SaveChanges();

        return Ok(mahalle);
    }

    // PUT: api/Mahalle/5
    [HttpPut("{id}")]
    public IActionResult PutMahalle(int id, Mahalle mahalle)
    {
        if (id != mahalle.mahalle_id)
        {
            return BadRequest();
        }

        var ilce = _context.ilce.Include(i => i.Sehir).FirstOrDefault(i => i.ilce_id == mahalle.ilce_id);
        if (ilce != null)
        {
            mahalle.Ilce = ilce;
        }

        _context.Entry(mahalle).State = EntityState.Modified;
        _context.SaveChanges();
        return NoContent();
    }

    // DELETE: api/Mahalle/5
    [HttpDelete("{id}")]
    public IActionResult DeleteMahalle(int id)
    {
        var mahalle = _context.mahalle.Find(id);
        if (mahalle == null)
        {
            return NotFound();
        }
        _context.mahalle.Remove(mahalle);
        _context.SaveChanges();
        return NoContent();
    }
}
