using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using tasinmaz_project.DataAccess;
using tasinmaz_project.Entities.Concrete;

namespace tasinmaz_project.Data
{
    public class KullaniciRepository : IKullaniciRepository
    {
        private readonly Context _context;

        public KullaniciRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Kullanici>> GetAllUsersAsync()
        {
            return await _context.kullanici.ToListAsync();
        }
    }
}
