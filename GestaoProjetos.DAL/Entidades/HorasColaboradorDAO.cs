using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoProjetos.DAL.Entidades
{
    [Table("HorasColaborador")]
    public class HorasColaboradorDAO
    {
        [Key]
        public long Id_HorasColaborador { get; set; }
        public ColaboradorDAO Colaborador { get; set; }
        public TarefaDAO Tarefa { get; set; }
        public double Horas { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
    }
}
