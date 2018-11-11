using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoProjetos.DTO
{
    public class ColaboradorTarefa
    {
        [Display(Name = "Código")]
        public long ID_ColaboradorTarefa { get; set; }
        public Colaborador Colaborador { get; set; }
        public Tarefa Tarefa { get; set; }
        [Display(Name = "Horas Estimadas")]
        public double Horas_Estimadas { get; set; }
    }
}
