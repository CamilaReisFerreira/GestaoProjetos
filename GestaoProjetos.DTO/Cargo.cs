using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoProjetos.DTO
{
    public class Cargo
    {
        [Display(Name = "Código")]
        public long Id_Cargo { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}
