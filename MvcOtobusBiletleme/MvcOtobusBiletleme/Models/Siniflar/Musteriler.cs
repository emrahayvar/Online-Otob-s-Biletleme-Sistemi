using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOtobusBiletleme.Models.Siniflar
{
    public class Musteriler
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Ad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string Soyad { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Telefon { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Cinsiyet { get; set; }
        public DateTime DogumTarih { get; set; }
        public int? Sehirlerid { get; set; }

        public ICollection<Biletler> Biletlers { get; set; }

        public virtual Sehirler Sehirler { get; set; }

    }
}