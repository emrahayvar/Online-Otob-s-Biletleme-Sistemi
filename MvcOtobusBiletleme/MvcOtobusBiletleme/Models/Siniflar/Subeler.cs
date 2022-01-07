using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOtobusBiletleme.Models.Siniflar
{
    public class Subeler
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string SubeAd { get; set; }
        public int Sehirlerid { get; set; }
        public bool Durum { get; set; }
        public virtual Sehirler Sehirler { get; set; }

        public ICollection<Calisanlar> Calisanlars { get; set; }
    }
}