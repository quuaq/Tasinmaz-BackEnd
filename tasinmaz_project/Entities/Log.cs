using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tasinmaz_project.Entities.Concrete
{
    public class Log
    {
        [Key, Column("log_id")]
        public int log_id { get; set; }
        public bool durum { get; set; }
        public string islem_tipi { get; set; }
        public string aciklama { get; set; }
        public DateTime tarih { get; set; }
        public string log_ip { get; set; }
        public int kullanici_id { get; set; }

        [ForeignKey("kullanici_id")]
        public virtual Kullanici Kullanici { get; set; }


    }
}
