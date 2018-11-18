using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoProjetos.DTO
{
    public class Projeto
    {
        [Display(Name = "Código")]
        public long Id_Projeto { get; set; }
        [Display(Name = "Razão Social")]
        [Required]
        public string Razao_Social { get; set; }
        [Required]
        public string CNPJ { get; set; }
        [Display(Name = "Quantidade de Horas")]
        public double Horas_Projeto { get; set; }
        [Display(Name = "Data Inicial do Contrato")]
        public DateTime Data_Inicial_Contrato { get; set; }
        [Display(Name = "Observação")]
        public string Observacoes { get; set; }
    }
}
