using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tasinmaz_project.Entities.Concrete
{
    public class Ilce
    {
        [Key, Column("ilce_id")]
        public int ilce_id { get; set; }
        public string ilce_ad { get; set; }
        public int sehir_id { get; set; }

        [ForeignKey("sehir_id")]
        public virtual Sehir Sehir { get; set; }
    }
}
