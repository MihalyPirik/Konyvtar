using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtar.Model
{
    public class Szerzo
    {
        [Key]
        public int szerzoID { get; set; }

        [Required]
        [StringLength(50)]
        public string Keresztnev { get; set; }

        [Required]
        [StringLength(50)]
        public string Vezeteknev { get; set; }

        public ICollection<Konyv> Konyvek { get; set; }

        public string TeljesNev { get { return $"{Keresztnev} {Vezeteknev}"; } }
    }
}
