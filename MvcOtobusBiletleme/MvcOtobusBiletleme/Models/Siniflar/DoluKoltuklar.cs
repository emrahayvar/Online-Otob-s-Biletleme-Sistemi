using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOtobusBiletleme.Models.Siniflar
{
    public class DoluKoltuklar
    {
        [Key]
        public int KoltukID { get; set; }

        public int BiletNo { get; set; }
        public DateTime KalkisZamani { get; set; }
        public int Seferlerid { get; set; }
        public int KalkisSehirid { get; set; }
        public virtual Seferler Seferler { get; set; }
        public virtual KalkisSehir KalkisSehir { get; set; }
    }
}