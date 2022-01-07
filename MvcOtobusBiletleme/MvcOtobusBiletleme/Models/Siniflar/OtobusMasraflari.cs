using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOtobusBiletleme.Models.Siniflar
{
    public class OtobusMasraflari
    {
        [Key]
        public int ID { get; set; }
        public decimal Tutar { get; set; }
        public int Calisanlarid { get; set; }
        public int Otobuslerid { get; set; }
        public int MasrafTipleriid { get; set; }
        public int Seferlerid { get; set; }
        public virtual Calisanlar Calisanlar { get; set; }
        public virtual Otobusler Otobusler { get; set; }
        public virtual MasrafTipleri MasrafTipleri { get; set; }
        public virtual Seferler Seferler { get; set; }
    }
}