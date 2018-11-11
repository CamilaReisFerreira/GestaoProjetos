using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoProjetos.DAL.Entidades
{
    [Table("ColaboradorTarefa")]
    public class ColaboradorTarefaDAO
    {
        [Key]
        public long ID_ColaboradorTarefa { get; set; }
        public long? ColaboradorId_Colaborador { get; set; }
        public long? TarefaId_Tarefa { get; set; }
        public double Horas_Estimadas { get; set; }

        public ColaboradorDAO Colaborador { get; set; }
        public TarefaDAO Tarefa { get; set; }
    }
}
