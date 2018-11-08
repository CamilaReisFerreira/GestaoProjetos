using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoProjetos.DTO
{
    public class Tarefa
    {
        public long Id_Tarefa { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public char Situacao { get; set; }
        public DateTime Data_Abertura { get; set; }
        public DateTime Data_Entrega { get; set; }
        public Projeto Projeto { get; set; }
        public IList<ColaboradorTarefa> ColaboradorTarefa { get; set; }
    }
}
