using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoProjetos.DTO
{
    public class HorasColaborador
    {
        public long Id_HorasColaborador { get; set; }
        public Colaborador Colaborador { get; set; }
        public Tarefa Tarefa { get; set; }
        public double Horas { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
    }
}
