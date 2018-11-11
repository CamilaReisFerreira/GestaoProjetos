using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GestaoProjetos.DTO
{
    public class Tarefa
    {
        [Display(Name = "Código")]
        public long Id_Tarefa { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Observação")]
        public string Observacao { get; set; }
        [Display(Name = "Situação")]
        public char Situacao { get; set; }
        [Display(Name = "Data de Abertura")]
        public DateTime Data_Abertura { get; set; }
        [Display(Name = "Data de Entrega")]
        public DateTime Data_Entrega { get; set; }
        public Projeto Projeto { get; set; }
        public IList<ColaboradorTarefa> ColaboradorTarefa { get; set; }

        public string Situacao_Exibir
        {
            get
            {
                switch (this.Situacao)
                {
                    case 'A':
                        return "Aguardando";
                    case 'D':
                        return "Desenvolvimento";
                    case 'E':
                        return "Encerrada";
                    case 'I':
                        return "Iniciada";
                    case 'P':
                        return "Pendente";
                    case 'T':
                        return "Testes";
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
