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
    public class Tanulo
    {
        [Key]
        public int TanuloID { get; set; }

        public string Keresztnev { get; set; }

        public string Vezeteknev { get; set; }

        public DateTime SzulDatum { get; set; }

        public bool No { get; set; }

        public string Osztaly { get; set; }

        public ICollection<Kolcsonzes> Kolcsonzesek { get; set; }

        [NotMapped]
        public string TeljesNev { get { return $"{Keresztnev} {Vezeteknev}"; } }
    }
}
