using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOtobusBiletleme.Models.Siniflar
{
    public class MasrafTipleri
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string MasrafAd { get; set; }
        public bool Durum { get; set; }

        public ICollection<OtobusMasraflari> OtobusMasraflaris { get; set; }
    }
}