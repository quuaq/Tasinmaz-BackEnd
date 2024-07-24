using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tasinmaz_project.Entities.Concrete
{
    public class Tasinmaz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("tasinmaz_id")]
        public int tasinmaz_id { get; set; }

        public string ada { get; set; }
        public string parsel { get; set; }
        public string nitelik { get; set; }
        public string koordinat { get; set; }
        public string adres { get; set; }

        public int mahalle_id { get; set; }

        [ForeignKey("mahalle_id")]
        public virtual Mahalle Mahalle { get; set; }
    }
}
