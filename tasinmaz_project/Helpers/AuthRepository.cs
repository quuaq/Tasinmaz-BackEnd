using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tasinmaz_project.DataAccess;
using tasinmaz_project.Entities.Concrete;

namespace tasinmaz_project.Helpers
{
    public class AuthRepository : IAuthRepository
    {
        private readonly Context _context;

        public AuthRepository(Context context)
        {
            _context = context;
        }

        public async Task<Kullanici> Login(string userName, string password)
        {
            var kullanici = await _context.kullanici.FirstOrDefaultAsync(x => x.kullanici_name == userName);
            if (kullanici == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(password, kullanici.password_hash, kullanici.password_salt))
            {
                return null;
            }

            return kullanici;
        }

        private bool VerifyPasswordHash(string password, byte[] password_hash, byte[] password_salt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(password_salt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != password_hash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public async Task<Kullanici> Register(Kullanici kullanici, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            kullanici.password_hash = passwordHash;
            kullanici.password_salt = passwordSalt;

            await _context.kullanici.AddAsync(kullanici);
            await _context.SaveChangesAsync();

            return kullanici;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string kullaniciName)
        {
            return await _context.kullanici.AnyAsync(x => x.kullanici_name == kullaniciName);
        }

        public async Task<IEnumerable<Kullanici>> GetUsers()
        {
            return await _context.kullanici.ToListAsync();
        }

        public async Task<Kullanici> GetUserById(int id)
        {
            return await _context.kullanici.FindAsync(id);
        }

        public async Task DeleteUser(Kullanici kullanici)
        {
            _context.kullanici.Remove(kullanici);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLogsByUserId(int userId)
        {
            var logs = await _context.log.Where(l => l.kullanici_id == userId).ToListAsync();
            _context.log.RemoveRange(logs);
            await _context.SaveChangesAsync();
        }
    }
}
