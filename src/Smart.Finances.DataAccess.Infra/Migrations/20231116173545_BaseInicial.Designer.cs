﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Smart.Finances.Infra.Persistence.Configurations;

#nullable disable

namespace Smart.Finances.Infra.Migrations
{
    [DbContext(typeof(SqlServerDbContext))]
    [Migration("20231116173545_BaseInicial")]
    partial class BaseInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Smart.Finances.Core.Entity.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("EhAtivo")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Smart.Finances.Core.Entity.Despesa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EhAtivo")
                        .HasColumnType("bit");

                    b.Property<bool>("EhRecorrente")
                        .HasColumnType("bit");

                    b.Property<int>("QuantidadeParcela")
                        .HasColumnType("int");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Despesa");
                });

            modelBuilder.Entity("Smart.Finances.Core.Entity.Parcelas", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("DespesaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PagamentoEm")
                        .HasColumnType("datetime2");

                    b.Property<double>("ValorParcela")
                        .HasColumnType("float");

                    b.Property<DateTime>("Vencimento")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DespesaId");

                    b.ToTable("Parcelas");
                });

            modelBuilder.Entity("Smart.Finances.Core.Entity.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AtualizadoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Smart.Finances.Core.Entity.Despesa", b =>
                {
                    b.HasOne("Smart.Finances.Core.Entity.Categoria", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Smart.Finances.Core.Entity.Usuario", "Usuario")
                        .WithMany("Despesas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Smart.Finances.Core.Entity.Parcelas", b =>
                {
                    b.HasOne("Smart.Finances.Core.Entity.Despesa", "Despesa")
                        .WithMany("Parcelas")
                        .HasForeignKey("DespesaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Despesa");
                });

            modelBuilder.Entity("Smart.Finances.Core.Entity.Despesa", b =>
                {
                    b.Navigation("Parcelas");
                });

            modelBuilder.Entity("Smart.Finances.Core.Entity.Usuario", b =>
                {
                    b.Navigation("Despesas");
                });
#pragma warning restore 612, 618
        }
    }
}
