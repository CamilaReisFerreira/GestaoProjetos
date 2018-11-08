using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoProjetos.DAL.Entidades
{
    [Table("Projeto")]
    public class ProjetoDAO
    {
        [Key]
        public long Id_Projeto { get; set; }
        public string Razao_Social { get; set; }
        public string CNPJ { get; set; }
        public double Horas_Projeto { get; set; }
        public DateTime Data_Inicial_Contrato { get; set; }
        public string Observacoes { get; set; }
    }
}
