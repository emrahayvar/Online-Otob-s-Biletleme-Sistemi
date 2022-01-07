using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOtobusBiletleme.Models.Siniflar
{
    public class Seferler
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string SeferAd { get; set; }
        public DateTime KalkisZamani{ get; set; }
        public DateTime VarisZamani { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string TahminiSure { get; set; }
        public decimal BiletTutar { get; set; }
        public int? Guzergahid { get; set; }
        public int? Calisanlarid { get; set; }
        public int? Otobuslerid { get; set; }
        public int? KalkisSehirid { get; set; }
        public int? VarisSehirid { get; set; }
        public DateTime IslemZaman { get; set; }

        public virtual Guzergah Guzergah { get; set; }
        public virtual Calisanlar Calisanlar { get; set; }
        public virtual Otobusler Otobusler { get; set; }
        public virtual KalkisSehir KalkisSehir { get; set; }
        public virtual VarisSehir VarisSehir { get; set; }

        public ICollection<Biletler> Biletlers { get; set; }
        public ICollection<DoluKoltuklar> DoluKoltuklars { get; set; }
        public ICollection<OtobusMasraflari> OtobusMasraflaris { get; set; }
    }
}