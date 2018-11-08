using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoProjetos.DTO
{
    public class Colaborador
    {
        public long Id_Colaborador { get; set; }
        public string Nome { get; set; }
        public Cargo Cargo { get; set; }
    }
}
