using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtar.Model
{
    public class Konyv
    {
        [Key]
        public int KonyvID { get; set; }

        [Required]
        [StringLength(50)]
        public string Cim { get; set; }

        public int? Oldalszam { get; set; }

        public int? Pontszam { get; set; }

        public int? SzerzoID { get; set; }

        public int? TipusID { get; set; }

        public Szerzo Szerzo { get; set; }

        public Tipus Tipus { get; set; }

        public ICollection<Kolcsonzes> Kolcsonzesek { get; set; }

        [NotMapped]
        public bool Elerheto { get; set; } = false;
    }
}
