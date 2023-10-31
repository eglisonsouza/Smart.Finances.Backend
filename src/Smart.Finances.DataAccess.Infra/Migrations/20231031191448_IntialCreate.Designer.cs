﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Smart.Finances.DataAccess.Infra.Persistence.Configurations;

#nullable disable

namespace Smart.Finances.DataAccess.Infra.Migrations
{
    [DbContext(typeof(SqlServerDbContext))]
    [Migration("20231031191448_IntialCreate")]
    partial class IntialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Smart.Finances.DataAccess.Core.Entity.Categoria", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("EhAtivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("Smart.Finances.DataAccess.Core.Entity.Despesa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<long>("CategoriaId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Valor")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Despesa");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Despesa");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Smart.Finances.DataAccess.Core.Entity.Parcelas", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("DespesaExtraId")
                        .HasColumnType("bigint");

                    b.Property<int>("Numero")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PagamentoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Vencimento")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DespesaExtraId");

                    b.ToTable("Parcelas");
                });

            modelBuilder.Entity("Smart.Finances.DataAccess.Core.Entity.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("AtualizadoEm")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CriadoEm")
                        .ValueGeneratedOnAdd()
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

            modelBuilder.Entity("Smart.Finances.DataAccess.Core.Entity.DespesaExtra", b =>
                {
                    b.HasBaseType("Smart.Finances.DataAccess.Core.Entity.Despesa");

                    b.Property<int>("QuantidadeParcela")
                        .HasColumnType("int");

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasIndex("UsuarioId");

                    b.HasDiscriminator().HasValue("DespesaExtra");
                });

            modelBuilder.Entity("Smart.Finances.DataAccess.Core.Entity.DespesaRecorrente", b =>
                {
                    b.HasBaseType("Smart.Finances.DataAccess.Core.Entity.Despesa");

                    b.Property<bool?>("EhAtivo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<long>("UsuarioId")
                        .HasColumnType("bigint");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Despesa", t =>
                        {
                            t.Property("UsuarioId")
                                .HasColumnName("DespesaRecorrente_UsuarioId");
                        });

                    b.HasDiscriminator().HasValue("DespesaRecorrente");
                });

            modelBuilder.Entity("Smart.Finances.DataAccess.Core.Entity.Despesa", b =>
                {
                    b.HasOne("Smart.Finances.DataAccess.Core.Entity.Categoria", "Categoria")
                        .WithMany("Despesas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Smart.Finances.DataAccess.Core.Entity.Parcelas", b =>
                {
                    b.HasOne("Smart.Finances.DataAccess.Core.Entity.DespesaExtra", "DespesaExtra")
                        .WithMany("Parcelas")
                        .HasForeignKey("DespesaExtraId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DespesaExtra");
                });

            modelBuilder.Entity("Smart.Finances.DataAccess.Core.Entity.DespesaExtra", b =>
                {
                    b.HasOne("Smart.Finances.DataAccess.Core.Entity.Usuario", "Usuario")
                        .WithMany("DespesasExtra")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Smart.Finances.DataAccess.Core.Entity.DespesaRecorrente", b =>
                {
                    b.HasOne("Smart.Finances.DataAccess.Core.Entity.Usuario", "Usuario")
                        .WithMany("DespesasRecorrente")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Smart.Finances.DataAccess.Core.Entity.Categoria", b =>
                {
                    b.Navigation("Despesas");
                });

            modelBuilder.Entity("Smart.Finances.DataAccess.Core.Entity.Usuario", b =>
                {
                    b.Navigation("DespesasExtra");

                    b.Navigation("DespesasRecorrente");
                });

            modelBuilder.Entity("Smart.Finances.DataAccess.Core.Entity.DespesaExtra", b =>
                {
                    b.Navigation("Parcelas");
                });
#pragma warning restore 612, 618
        }
    }
}
