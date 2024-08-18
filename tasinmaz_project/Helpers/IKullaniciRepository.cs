using System.Collections.Generic;
using System.Threading.Tasks;
using tasinmaz_project.Entities.Concrete;

namespace tasinmaz_project.Data
{
    public interface IKullaniciRepository
    {
        Task<IEnumerable<Kullanici>> GetAllUsersAsync();
    }
}
