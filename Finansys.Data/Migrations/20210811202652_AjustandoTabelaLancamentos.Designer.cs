﻿// <auto-generated />
using System;
using Finansys.Data.Repository.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Finansys.Data.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20210811202652_AjustandoTabelaLancamentos")]
    partial class AjustandoTabelaLancamentos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("Finansys.Data.Repository.DTOs.CategoriaDTO", b =>
                {
                    b.Property<string>("CategoriaId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Descricao")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UsuarioId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("CategoriaId");

                    b.ToTable("Tb_Categorias");
                });

            modelBuilder.Entity("Finansys.Data.Repository.DTOs.CategoriaOrcamentoDTO", b =>
                {
                    b.Property<string>("CategoriaId")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("OrcamentoId")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("longtext");

                    b.Property<double>("ValorJaGasto")
                        .HasColumnType("double");

                    b.Property<double>("ValorLimite")
                        .HasColumnType("double");

                    b.HasKey("CategoriaId", "OrcamentoId");

                    b.HasIndex("OrcamentoId");

                    b.ToTable("CategoriaOrcamento");
                });

            modelBuilder.Entity("Finansys.Data.Repository.DTOs.ControleOrcamentarioDTO", b =>
                {
                    b.Property<string>("ControleOrcamentarioId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<double>("Despesa")
                        .HasColumnType("double");

                    b.Property<DateTime>("Fim")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("MesReferencia")
                        .HasColumnType("longtext");

                    b.Property<double>("Saldo")
                        .HasColumnType("double");

                    b.Property<string>("UsuarioId")
                        .HasColumnType("longtext");

                    b.Property<double>("ValorMensal")
                        .HasColumnType("double");

                    b.HasKey("ControleOrcamentarioId");

                    b.ToTable("ControleOrcamentarioDTOs");
                });

            modelBuilder.Entity("Finansys.Data.Repository.DTOs.LancamentoDTO", b =>
                {
                    b.Property<string>("LancamentoId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CategoriaId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ControleOrcamentarioId")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TipoLancamento")
                        .HasColumnType("int");

                    b.Property<string>("UsuarioId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<double>("Valor")
                        .HasColumnType("double");

                    b.HasKey("LancamentoId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ControleOrcamentarioId");

                    b.ToTable("Tb_Lancamentos");
                });

            modelBuilder.Entity("Finansys.Data.Repository.DTOs.CategoriaOrcamentoDTO", b =>
                {
                    b.HasOne("Finansys.Data.Repository.DTOs.CategoriaDTO", "CategoriaDTO")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Finansys.Data.Repository.DTOs.ControleOrcamentarioDTO", "OrcamentoDTO")
                        .WithMany()
                        .HasForeignKey("OrcamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaDTO");

                    b.Navigation("OrcamentoDTO");
                });

            modelBuilder.Entity("Finansys.Data.Repository.DTOs.LancamentoDTO", b =>
                {
                    b.HasOne("Finansys.Data.Repository.DTOs.CategoriaDTO", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId");

                    b.HasOne("Finansys.Data.Repository.DTOs.ControleOrcamentarioDTO", "ControleOrcamentarioDTO")
                        .WithMany()
                        .HasForeignKey("ControleOrcamentarioId");

                    b.Navigation("Categoria");

                    b.Navigation("ControleOrcamentarioDTO");
                });
#pragma warning restore 612, 618
        }
    }
}
