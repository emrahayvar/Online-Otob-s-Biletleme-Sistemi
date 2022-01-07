using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOtobusBiletleme.Models.Siniflar
{
    public class Hatalar
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Numara { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(1000)]
        public string Mesaj { get; set; }
        public DateTime Zaman { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Prosedur { get; set; }
    }
}