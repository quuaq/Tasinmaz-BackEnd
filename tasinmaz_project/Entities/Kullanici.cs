

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tasinmaz_project.Entities.Concrete
{
    public class Kullanici
    {
        [Key, Column("kullanici_id")]
        public int kullanici_id { get; set; }
        public string kullanici_name { get; set; }
        public byte[] password_hash { get; set; }
        public byte[] password_salt { get; set; }
        public string role { get; set; } // Kullanıcı rolü eklendi
    }
}
