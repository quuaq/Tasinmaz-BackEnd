using System.Collections.Generic;
using System.Threading.Tasks;
using tasinmaz_project.Entities.Concrete;

namespace tasinmaz_project.Helpers
{
    public interface IAuthRepository
    {
        Task<Kullanici> Register(Kullanici kullanici, string password);
        Task<Kullanici> Login(string userName, string password);
        Task<bool> UserExists(string kullaniciname);
        Task<IEnumerable<Kullanici>> GetUsers();
        Task<Kullanici> GetUserById(int id);
        Task DeleteUser(Kullanici kullanici);
        Task DeleteLogsByUserId(int userId); // Yeni metot eklendi
    }
}
