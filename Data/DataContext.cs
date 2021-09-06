
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using T4i_WebAPI.model;

namespace T4i_WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Projeto> projetos { get; set; }

        public DbSet<Dev> dev { get; set; }

        public DbSet<Works> works { get; set; }

        public DbSet<ProjetosWorks> pw { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProjetosWorks>().HasKey(AD => new { AD.projetoId , AD.worksId });

            builder.Entity<Dev>().HasData(new List<Dev>(){
            new Dev(1,"Alessandro Bezerra","Engenheiro de Dados"),
            new Dev(2,"Juliane", "Engenheira de software"),
            new Dev(3,"Samuel", "Analista Sênior"),
            new Dev(4,"André Silva", "Engenheiro de software"),
            new Dev(5,"Anderson Gonçalves", "Estagiário full-stack"),
            new Dev(6,"Rodrigo Nunes de Lucena", "Desenvolvedor de software sênior"),
            new Dev(7,"Tomaz Santos Junior", "Engenheiro de sofware full-Stack Sênior"),
            new Dev(8,"Igor Albuquerque", "Engenheiro de software"),
            new Dev(9,"Vinicius Santos", "Estagiário Futuro Engenheiro")
        });
            builder.Entity<Projeto>().HasData(new List<Projeto>(){
            new Projeto(1,"NetWorks","Rede de contatos e negócios"),
            new Projeto(2,"System For T4i", "Sistema para administração de serviços"),
            new Projeto(3,"System For Google","Sistema para verificar pré-requisitos de padrões de arquitetura dentro de um software"),
            new Projeto(4,"Upgrade Our System","Melhorias em nosso sistema"),
            new Projeto(5,"Create An Innovative System","Planejar, estruturar e criar um sistema inovador")
        });
            // Relacionamento one for n
            builder.Entity<Works>().HasData(new List<Works>(){
            new Works(1,2,"Equipe A"),
            new Works(2,3,"Equipe B"),
            new Works(3,5,"Equipe C"),
            new Works(4,8,"Equipe E"),
            new Works(5,9,"Equipe D"),
        });
            builder.Entity<ProjetosWorks>().HasData(new List<ProjetosWorks>(){
            new ProjetosWorks(){projetoId = 1, worksId = 2},
            new ProjetosWorks(){projetoId = 2, worksId = 3},
            new ProjetosWorks(){projetoId = 3, worksId = 5},
            new ProjetosWorks(){projetoId = 4, worksId = 4},
            new ProjetosWorks(){projetoId = 5, worksId = 5},            
        });
        }

    }
}