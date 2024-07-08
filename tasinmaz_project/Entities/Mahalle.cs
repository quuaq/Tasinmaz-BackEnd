using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using tasinmaz_project.Entities.Concrete;

namespace tasinmaz_project.Entities.Concrete
{
    public class Mahalle
    {
        [Key, Column("mahalle_id")]

        public int mahalle_id { get; set; }
        public string mahalle_ad { get; set; }
        public int ilce_id { get; set; }

        [ForeignKey("ilce_id")]
        public virtual Ilce Ilce { get; set; }
    }
}
