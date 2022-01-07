using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOtobusBiletleme.Models.Siniflar
{
    public class Otobusler
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Plaka { get; set; }
        public int KoltukSayisi { get; set; }
        public int Markalarid { get; set; }
        public bool AktifMi { get; set; }
        public virtual Markalar Markalar { get; set; }

        public ICollection<OtobusMasraflari> OtobusMasraflaris { get; set; }

        public ICollection<Seferler> Seferlers { get; set; }
    }
}