using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tasinmaz_project.Entities.Concrete
{
    public class Sehir
    {
        [Key, Column("sehir_id")]
        public int sehir_id { get; set; }
        public string sehir_ad { get; set; }

    }
}
