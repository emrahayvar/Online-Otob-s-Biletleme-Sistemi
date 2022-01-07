using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOtobusBiletleme.Models.Siniflar
{
    public class Calisanlar
    {
        [Key]
        public int ID{ get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Ad{ get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Soyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Telefon{ get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string Email{ get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(150)]
        public string EvAdres{ get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string KullaniciAd{ get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Sifre{ get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string Yetki { get; set; }

        public int Subelerid { get; set; }
        public int CalisanTypeid { get; set; }
        public bool Durum { get; set; }

        public virtual Subeler Subeler { get; set; }

        public virtual CalisanType CalisanType { get; set; }
        public ICollection<Biletler> Biletlers { get; set; }

        public ICollection<PersonelGirisCikis> PersonelGirisCikis1 { get; set; }
        public ICollection<Seferler> Seferlers { get; set; }
        public ICollection<OtobusMasraflari> OtobusMasraflaris { get; set; }

    }
}