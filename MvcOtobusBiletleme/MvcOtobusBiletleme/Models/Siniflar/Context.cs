using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MvcOtobusBiletleme.Models.Siniflar
{
    public class Context : DbContext
    {
        public DbSet<Biletler> Biletlers { get; set; }
        public DbSet<Calisanlar> Calisanlars { get; set; }
        public DbSet<CalisanType> CalisanTypes { get; set; }
        public DbSet<DoluKoltuklar> DoluKoltuklars { get; set; }
        public DbSet<Guzergah> Guzergahs { get; set; }
        public DbSet<Hatalar> Hatalars { get; set; }
        public DbSet<Markalar> Markalars { get; set; }
        public DbSet<MasrafTipleri> MasrafTipleris { get; set; }
        public DbSet<Musteriler> Musterilers { get; set; }
        public DbSet<Otobusler> Otobuslers { get; set; }
        public DbSet<OtobusMasraflari> OtobusMasraflaris { get; set; }
        public DbSet<PersonelGirisCikis> PersonelGirisCikis1 { get; set; }
        public DbSet<Seferler> Seferlers { get; set; }
        public DbSet<Sehirler> Sehirlers { get; set; }
        public DbSet<Subeler> Subelers { get; set; }
        public DbSet<KalkisSehir> KalkisSehirs { get; set; }
        public DbSet<VarisSehir> VarisSehirs { get; set; }
    }
}