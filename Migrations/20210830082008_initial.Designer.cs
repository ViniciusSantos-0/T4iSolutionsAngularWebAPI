﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using T4i_WebAPI.Data;

namespace T4i_WebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210830082008_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("T4i_WebAPI.model.Dev", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.Property<string>("position")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("dev");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "Alessandro Bezerra",
                            position = "Engenheiro de Dados"
                        },
                        new
                        {
                            id = 2,
                            name = "Juliane",
                            position = "Engenheira de software"
                        },
                        new
                        {
                            id = 3,
                            name = "Samuel",
                            position = "Analista Sênior"
                        },
                        new
                        {
                            id = 4,
                            name = "André Silva",
                            position = "Engenheiro de software"
                        },
                        new
                        {
                            id = 5,
                            name = "Anderson Gonçalves",
                            position = "Estagiário full-stack"
                        },
                        new
                        {
                            id = 6,
                            name = "Rodrigo Nunes de Lucena",
                            position = "Desenvolvedor de software sênior"
                        },
                        new
                        {
                            id = 7,
                            name = "Tomaz Santos Junior",
                            position = "Engenheiro de sofware full-Stack Sênior"
                        },
                        new
                        {
                            id = 8,
                            name = "Igor Albuquerque",
                            position = "Engenheiro de software"
                        },
                        new
                        {
                            id = 9,
                            name = "Vinicius Santos",
                            position = "Estagiário Futuro Engenheiro"
                        });
                });

            modelBuilder.Entity("T4i_WebAPI.model.Projeto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Devid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("Devid");

                    b.ToTable("projetos");

                    b.HasData(
                        new
                        {
                            id = 1,
                            description = "Rede de contatos e negócios",
                            name = "NetWorks"
                        },
                        new
                        {
                            id = 2,
                            description = "Sistema para administração de serviços",
                            name = "System For T4i"
                        },
                        new
                        {
                            id = 3,
                            description = "Sistema para verificar pré-requisitos de padrões de arquitetura dentro de um software",
                            name = "System For Google"
                        },
                        new
                        {
                            id = 4,
                            description = "Melhorias em nosso sistema",
                            name = "Upgrade Our System"
                        },
                        new
                        {
                            id = 5,
                            description = "Planejar, estruturar e criar um sistema inovador",
                            name = "Create An Innovative System"
                        });
                });

            modelBuilder.Entity("T4i_WebAPI.model.ProjetosWorks", b =>
                {
                    b.Property<int>("worksId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("projetoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("worksId", "projetoId");

                    b.HasIndex("projetoId");

                    b.ToTable("pw");

                    b.HasData(
                        new
                        {
                            worksId = 1,
                            projetoId = 1
                        },
                        new
                        {
                            worksId = 4,
                            projetoId = 2
                        },
                        new
                        {
                            worksId = 3,
                            projetoId = 3
                        },
                        new
                        {
                            worksId = 2,
                            projetoId = 4
                        },
                        new
                        {
                            worksId = 5,
                            projetoId = 5
                        });
                });

            modelBuilder.Entity("T4i_WebAPI.model.Works", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("devid")
                        .HasColumnType("INTEGER");

                    b.Property<int>("idDev")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("devid");

                    b.ToTable("works");

                    b.HasData(
                        new
                        {
                            id = 1,
                            idDev = 2
                        },
                        new
                        {
                            id = 2,
                            idDev = 3
                        },
                        new
                        {
                            id = 3,
                            idDev = 5
                        },
                        new
                        {
                            id = 4,
                            idDev = 2
                        },
                        new
                        {
                            id = 5,
                            idDev = 9
                        });
                });

            modelBuilder.Entity("T4i_WebAPI.model.Projeto", b =>
                {
                    b.HasOne("T4i_WebAPI.model.Dev", null)
                        .WithMany("projetos")
                        .HasForeignKey("Devid");
                });

            modelBuilder.Entity("T4i_WebAPI.model.ProjetosWorks", b =>
                {
                    b.HasOne("T4i_WebAPI.model.Projeto", "projeto")
                        .WithMany()
                        .HasForeignKey("projetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("T4i_WebAPI.model.Works", "works")
                        .WithMany()
                        .HasForeignKey("worksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("projeto");

                    b.Navigation("works");
                });

            modelBuilder.Entity("T4i_WebAPI.model.Works", b =>
                {
                    b.HasOne("T4i_WebAPI.model.Dev", "dev")
                        .WithMany()
                        .HasForeignKey("devid");

                    b.Navigation("dev");
                });

            modelBuilder.Entity("T4i_WebAPI.model.Dev", b =>
                {
                    b.Navigation("projetos");
                });
#pragma warning restore 612, 618
        }
    }
}
