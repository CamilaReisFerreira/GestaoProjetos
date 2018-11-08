using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoProjetos.DTO
{
    public class ColaboradorTarefa
    {
        public long ID_ColaboradorTarefa { get; set; }
        public Colaborador Colaborador { get; set; }
        public Tarefa Tarefa { get; set; }
        public double Horas_Estimadas { get; set; }
    }
}
