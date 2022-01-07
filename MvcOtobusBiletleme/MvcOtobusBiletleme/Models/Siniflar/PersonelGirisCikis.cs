using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOtobusBiletleme.Models.Siniflar
{
    public class PersonelGirisCikis
    {
        [Key]
        public int ID { get; set; }
        public DateTime Giris { get; set; }
        public DateTime Cikis { get; set; }
        public int Calisanlarid { get; set; }
        public virtual Calisanlar Calisanlar { get; set; }
    }
}