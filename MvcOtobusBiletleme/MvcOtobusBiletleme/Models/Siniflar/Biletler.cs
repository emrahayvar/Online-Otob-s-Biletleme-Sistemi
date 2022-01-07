using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOtobusBiletleme.Models.Siniflar
{
    public class Biletler
    {
        [Key]
        public int Biletlerid { get; set; }
        public DateTime IslemZaman { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string YolcuAd { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string YolcuSoyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string YolcuCinsiyet { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(15)]
        public string SatisMiRezarvasyonMu { get; set; }
        public DateTime KalkisZamani { get; set; }
        public int KoltukNo { get; set; }      
        public decimal Ucret { get; set; }
        public int Calisanlarid { get; set; }
        public int Musterilerid { get; set; }
        public int Seferlerid { get; set; }
        public virtual Calisanlar Calisanlar { get; set; }
        public virtual Musteriler Musteriler { get; set; }
        public virtual Seferler Seferler { get; set; }
    }
}