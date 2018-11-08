using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GestaoProjetos.DAL.Entidades
{
    [Table("Cargo")]
    public class CargoDAO
    {
        [Key]
        public long Id_Cargo { get; set; }
        public string Descricao { get; set; }
    }
}
