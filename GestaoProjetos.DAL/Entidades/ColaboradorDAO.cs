using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoProjetos.DAL.Entidades
{
    [Table("Colaborador")]
    public class ColaboradorDAO
    {
        [Key]
        public long Id_Colaborador { get; set; }
        public string Nome { get; set; }
        public CargoDAO Cargo { get; set; }
    }
}
