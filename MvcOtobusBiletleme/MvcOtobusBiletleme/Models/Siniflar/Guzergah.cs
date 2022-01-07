using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOtobusBiletleme.Models.Siniflar
{
    public class Guzergah
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Tanim { get; set; }
        public int VarisSehirid { get; set; }
        public int KalkisSehirid { get; set; }
        public bool Durum { get; set; }

        public virtual KalkisSehir KalkisSehir { get; set; }
        public virtual VarisSehir VarisSehir { get; set; }

        public ICollection<Seferler> Seferlers { get; set; }
    }
}