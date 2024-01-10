using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Alunos
    {
        [Required, MinLength(3), MaxLength(30)]
        public string Nome { get; set; }

        [Required, Key, MinLength(1), MaxLength(5)]
        public int Num { get; set; }

        public string Distrito { get; set; }

        public string Concelho { get; set; }

        /*
        [Required, StringLength(8)]
        public string Cp { get; set; }
        */
    }
}
