using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoProjetos.DTO
{
    public class Colaborador
    {
        [Display(Name = "Código")]
        public long Id_Colaborador { get; set; }
        public string Nome { get; set; }
        public Cargo Cargo { get; set; }
    }
}
