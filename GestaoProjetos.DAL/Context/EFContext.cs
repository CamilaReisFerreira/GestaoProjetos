using GestaoProjetos.DAL.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoProjetos.DAL.Context
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options)
            : base(options) { }

        public DbSet<CargoDAO> Cargos { get; set; }
        public DbSet<ColaboradorDAO> Colaboradores { get; set; }
        public DbSet<ProjetoDAO> Projetos { get; set; }
        public DbSet<TarefaDAO> Tarefas { get; set; }
        public DbSet<ColaboradorTarefaDAO> ColaboradoresTarefa { get; set; }
        public DbSet<HorasColaboradorDAO> HorasColaboradores { get; set; }
    }
}
