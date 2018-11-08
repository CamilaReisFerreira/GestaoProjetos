using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoProjetos.DTO
{
    public class Projeto
    {
        public long Id_Projeto { get; set; }
        public string Razao_Social { get; set; }
        public string CNPJ { get; set; }
        public double Horas_Projeto { get; set; }
        public DateTime Data_Inicial_Contrato { get; set; }
        public string Observacoes { get; set; }
    }
}
