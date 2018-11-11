using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoProjetos.DTO
{
    public class HorasColaborador
    {
        [Display(Name = "Código")]
        public long Id_HorasColaborador { get; set; }
        public Colaborador Colaborador { get; set; }
        public Tarefa Tarefa { get; set; }
        public double Horas { get; set; }
        public DateTime Data { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}
