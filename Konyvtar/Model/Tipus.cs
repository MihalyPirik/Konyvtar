using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtar.Model
{
    public class Tipus
    {
        [Key]
        public int TipusID { get; set; }

        [Required]
        [StringLength(50)]
        public string Nev { get; set; }
    }
}
