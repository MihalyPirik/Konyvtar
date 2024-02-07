using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtar.Model
{
    public class Kolcsonzes
    {
        [Key]
        public int KolcsonzesID { get; set; }

        public int? TanuloID { get; set; }

        public int? KonyvID { get; set; }

        public DateTime Elvitel { get; set; }

        public DateTime Visszahozas { get; set; }
        [DefaultValue(false)]
        public bool Visszahozta { get; set; }

        public Konyv Konyv { get; set; }

        public Tanulo Tanulo { get; set; }
        [NotMapped]
        public string VisszahoztaText { get { return Visszahozta ? "Igen" : "Nem"; } }
    }
}
