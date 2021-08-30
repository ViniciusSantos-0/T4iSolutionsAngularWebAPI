
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using T4i_WebAPI.model;

namespace T4i_WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<Projeto> projetos { get; set; }

        public DbSet<Dev> fev { get; set; }

        public DbSet<Works> works { get; set; }

        public DbSet<ProjetosWorks> pw { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
builder.Entity<ProjetosWorks>().HasKey(AD => new { AD.worksId, AD.projetoId });

        builder.Entity<Dev>().HasData(new List<Dev>(){
            new Dev(1,"Teste","fdf"),
            new Dev(2,"Teste2", "sdsd")
        });
        builder.Entity<Projeto>().HasData(new List<Projeto>(){
            new Projeto(1,"Teste"),
            new Projeto(2,"Teste2")
        });
        builder.Entity<Works>().HasData(new List<Works>(){
            new Works(),
            new Works()
        });
        builder.Entity<ProjetosWorks>().HasData(new List<ProjetosWorks>(){
            new ProjetosWorks(),
            new ProjetosWorks()
        });
        }

    }
}