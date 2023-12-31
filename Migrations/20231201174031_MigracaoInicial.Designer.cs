﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApiBiblioteca.Context;

#nullable disable

namespace WebApiBiblioteca.Migrations
{
    [DbContext(typeof(WebApiBibliotecaContext))]
    [Migration("20231201174031_MigracaoInicial")]
    partial class MigracaoInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApiBiblioteca.Model.Autor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int?>("LivroID")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("LivroID");

                    b.ToTable("Autores");
                });

            modelBuilder.Entity("WebApiBiblioteca.Model.Contato", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int>("Celular")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("WebApiBiblioteca.Model.Empréstimo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("DataDevolução")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DataEmpréstimo")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<string>("Título")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Empréstimos");
                });

            modelBuilder.Entity("WebApiBiblioteca.Model.Genero", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<int?>("LivroID")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("LivroID");

                    b.ToTable("Generos");
                });

            modelBuilder.Entity("WebApiBiblioteca.Model.Livro", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Titulo")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Livros");
                });

            modelBuilder.Entity("WebApiBiblioteca.Model.Autor", b =>
                {
                    b.HasOne("WebApiBiblioteca.Model.Livro", null)
                        .WithMany("Autores")
                        .HasForeignKey("LivroID");
                });

            modelBuilder.Entity("WebApiBiblioteca.Model.Genero", b =>
                {
                    b.HasOne("WebApiBiblioteca.Model.Livro", null)
                        .WithMany("Generos")
                        .HasForeignKey("LivroID");
                });

            modelBuilder.Entity("WebApiBiblioteca.Model.Livro", b =>
                {
                    b.Navigation("Autores");

                    b.Navigation("Generos");
                });
#pragma warning restore 612, 618
        }
    }
}
