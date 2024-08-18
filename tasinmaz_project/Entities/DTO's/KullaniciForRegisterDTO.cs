using NetTopologySuite.Geometries;

namespace tasinmaz_project.Entities.DTO_s
{
    public class KullaniciForRegisterDTO
    {
        public string kullanici_name { get; set; }
        public string Password { get; set; }
        public int Kullanici_id { get; set; }
        public string Role { get; set; } // Kullanıcı rolü eklendi
    }
}
