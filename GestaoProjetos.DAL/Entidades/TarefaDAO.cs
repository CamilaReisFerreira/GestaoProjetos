using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoProjetos.DAL.Entidades
{
    [Table("Tarefa")]
    public class TarefaDAO
    {
        [Key]
        public long Id_Tarefa { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public char Situacao { get; set; }
        public DateTime Data_Abertura { get; set; }
        public DateTime Data_Entrega { get; set; }
        public ProjetoDAO Projeto { get; set; }
    }
}
